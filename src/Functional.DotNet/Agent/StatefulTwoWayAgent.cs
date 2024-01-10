using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Functional.DotNet
{
    /// <summary>
    /// Represents a stateful two-way agent that maintains state and allows for both sending messages and receiving replies.
    /// </summary>
    /// <typeparam name="State">The type of state the agent maintains.</typeparam>
    /// <typeparam name="Msg">The type of message the agent will process.</typeparam>
    /// <typeparam name="Reply">The type of reply the agent will provide.</typeparam>
    class StatefulTwoWayAgent<State, Msg, Reply> : Agent<Msg, Reply>
    {
        private State state;
        private readonly ActionBlock<(Msg, TaskCompletionSource<Reply>)> actionBlock;

        /// <summary>
        /// Initializes a new instance of the StatefulTwoWayAgent class with an initial state and a synchronous processing function.
        /// </summary>
        /// <param name="initialState">The initial state of the agent.</param>
        /// <param name="process">A function that processes messages and returns a tuple of the new state and a reply.</param>
        public StatefulTwoWayAgent(State initialState, Func<State, Msg, (State, Reply)> process)
        {
            state = initialState;

            actionBlock = new ActionBlock<(Msg, TaskCompletionSource<Reply>)>(
                t =>
                {
                    var result = process(state, t.Item1);
                    state = result.Item1;
                    t.Item2.SetResult(result.Item2);
                });
        }

        /// <summary>
        /// Initializes a new instance of the StatefulTwoWayAgent class with an initial state and an asynchronous processing function.
        /// </summary>
        /// <param name="initialState">The initial state of the agent.</param>
        /// <param name="process">An asynchronous function that processes messages and returns a tuple of the new state and a reply.</param>
        public StatefulTwoWayAgent(State initialState, Func<State, Msg, Task<(State State, Reply Reply)>> process)
        {
            state = initialState;

            actionBlock = new ActionBlock<(Msg Message, TaskCompletionSource<Reply> Reply)>(
                async t => await process(state, t.Message)
                    .ContinueWith(task =>
                    {
                        if (task.Status == TaskStatus.Faulted)
                            t.Reply.SetException(task.Exception!);
                        else
                        {
                            state = task.Result.State;
                            t.Reply.SetResult(task.Result.Reply);
                        }
                    }));
        }

        /// <summary>
        /// Asynchronously sends a message to the agent and awaits a reply.
        /// </summary>
        /// <param name="message">The message to send to the agent.</param>
        /// <returns>A task representing the asynchronous operation and containing the reply.</returns>
        public Task<Reply> Tell(Msg message)
        {
            var tcs = new TaskCompletionSource<Reply>();
            actionBlock.Post((message, tcs));
            return tcs.Task;
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet
{

    /// <summary>
    /// Provides static methods to create different types of agents.
    /// </summary>
    public static class Agent
    {
        /// <summary>
        /// Starts a stateless agent that processes messages synchronously.
        /// </summary>
        /// <typeparam name="Msg">The type of message the agent will process.</typeparam>
        /// <param name="action">The action to process messages.</param>
        /// <returns>A stateless agent.</returns>
        public static Agent<Msg> Start<Msg>(Action<Msg> action)
            => new StatelessAgent<Msg>(action);

        /// <summary>
        /// Starts a stateful agent with an initial state and a synchronous processing function.
        /// </summary>
        /// <typeparam name="State">The type of state the agent maintains.</typeparam>
        /// <typeparam name="Msg">The type of message the agent will process.</typeparam>
        /// <param name="initialState">The initial state of the agent.</param>
        /// <param name="process">The function to process messages and update the state.</param>
        /// <returns>A stateful agent.</returns>
        public static Agent<Msg> Start<State, Msg>(State initialState, Func<State, Msg, State> process)
            => new StatefulAgent<State, Msg>(initialState, process);

        // ... [Other Start methods with similar documentation]

        /// <summary>
        /// Starts a two-way agent with an initial state and a synchronous processing function.
        /// </summary>
        /// <typeparam name="State">The type of state the agent maintains.</typeparam>
        /// <typeparam name="Msg">The type of message the agent will process.</typeparam>
        /// <typeparam name="Reply">The type of reply the agent will provide.</typeparam>
        /// <param name="initialState">The initial state of the agent.</param>
        /// <param name="process">The function to process messages and provide replies.</param>
        /// <returns>A two-way agent.</returns>
        public static Agent<Msg, Reply> Start<State, Msg, Reply>(State initialState, Func<State, Msg, (State, Reply)> process)
            => new StatefulTwoWayAgent<State, Msg, Reply>(initialState, process);
    }



    /// <summary>
    /// Defines the contract for an agent that processes messages.
    /// </summary>
    /// <typeparam name="Msg">The type of message to process.</typeparam>
    public interface Agent<in Msg>
    {
        /// <summary>
        /// Processes a message.
        /// </summary>
        /// <param name="message">The message to be processed.</param>
        void Tell(Msg message);
    }

    /// <summary>
    /// Defines the contract for a two-way agent that processes messages and provides replies.
    /// </summary>
    /// <typeparam name="Msg">The type of message to process.</typeparam>
    /// <typeparam name="Reply">The type of reply to return.</typeparam>
    public interface Agent<in Msg, Reply>
    {
        /// <summary>
        /// Processes a message and provides a reply.
        /// </summary>
        /// <param name="message">The message to be processed.</param>
        /// <returns>The reply to the message.</returns>
        Task<Reply> Tell(Msg message);
    }
}

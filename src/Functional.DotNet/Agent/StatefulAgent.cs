using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Functional.DotNet
{


    /// <summary>
    /// Implements a stateful agent that processes messages and maintains a state.
    /// </summary>
    /// <typeparam name="State">The type of state the agent maintains.</typeparam>
    /// <typeparam name="Msg">The type of message the agent processes.</typeparam>
    class StatefulAgent<State, Msg> : Agent<Msg>
    {
        private State state;
        private readonly ActionBlock<Msg> actionBlock;

        /// <summary>
        /// Initializes a new instance of the StatefulAgent class with an initial state and a synchronous processing function.
        /// </summary>
        /// <param name="initialState">The initial state of the agent.</param>
        /// <param name="process">The function to process messages and update the state.</param>
        public StatefulAgent(State initialState, Func<State, Msg, State> process)
        {
            state = initialState;
            actionBlock = new ActionBlock<Msg>(msg => state = process(state, msg));
        }

        /// <summary>
        /// Processes the given message.
        /// </summary>
        /// <param name="message">The message to process.</param>
        public void Tell(Msg message) => actionBlock.Post(message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Functional.DotNet
{

    /// <summary>
    /// Implements a stateless agent that processes messages synchronously or asynchronously.
    /// </summary>
    /// <typeparam name="Msg">The type of message the agent processes.</typeparam>
    class StatelessAgent<Msg> : Agent<Msg>
    {
        private readonly ActionBlock<Msg> actionBlock;

        /// <summary>
        /// Initializes a new instance of the StatelessAgent class with a synchronous processing function.
        /// </summary>
        /// <param name="process">The action to process messages.</param>
        public StatelessAgent(Action<Msg> process)
        {
            actionBlock = new ActionBlock<Msg>(process);
        }

        /// <summary>
        /// Processes the given message.
        /// </summary>
        /// <param name="message">The message to process.</param>
        public void Tell(Msg message) => actionBlock.Post(message);
    }
}

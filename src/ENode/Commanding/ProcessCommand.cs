﻿using System;

namespace ENode.Commanding
{
    /// <summary>Represents an abstract process command which associated with a specific business process.
    /// </summary>
    [Serializable]
    public abstract class ProcessCommand<TAggregateRootId> : Command<TAggregateRootId>, IProcessCommand
    {
        /// <summary>Represents the process id.
        /// </summary>
        public string ProcessId { get; private set; }

        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="retryCount"></param>
        protected ProcessCommand(string commandId, object processId, int retryCount) : this(commandId, processId, default(TAggregateRootId), retryCount) { }
        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="aggregateRootId"></param>
        protected ProcessCommand(string commandId, object processId, TAggregateRootId aggregateRootId) : this(commandId, processId, aggregateRootId, DefaultRetryCount) { }
        /// <summary>Parameterized constructor.
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="aggregateRootId"></param>
        /// <param name="retryCount"></param>
        protected ProcessCommand(string commandId, object processId, TAggregateRootId aggregateRootId, int retryCount) : base(commandId, aggregateRootId, retryCount)
        {
            if (processId == null)
            {
                throw new ArgumentNullException("processId");
            }
            ProcessId = processId.ToString();
        }

        /// <summary>Returns the command type name.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}

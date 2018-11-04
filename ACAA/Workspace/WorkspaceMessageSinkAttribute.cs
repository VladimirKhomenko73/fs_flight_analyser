using System;

namespace ACAA.Workspace
{
    /// <summary>
    /// This attribute allows a method to be targeted as a recipient for a message.
    /// It requires that the Type is registered with the MessageMediator through the
    /// <seealso cref="MessageWorkspace.Register"/> method
    /// </summary>
    /// <example>
    /// <![CDATA[
    /// [WorkspaceMessageSinkAttribute("DoBackgroundCheck")]
    /// void OnBackgroundCheck(object parameter) { ... }
    /// 
    /// mediator.NotifyColleagues("DoBackgroundCheck", new CheckParameters());
    /// ...
    /// mediator.NotifyColleagues(new SomeDataClass(...));
    /// 
    /// ]]>
    /// </example>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class WorkspaceMessageSinkAttribute : Attribute
    {
        /// <summary>
        /// Message key
        /// </summary>
        public object MessageKey { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WorkspaceMessageSinkAttribute()
        {
            MessageKey = null;
        }

        /// <summary>
        /// Constructor that takes a message key
        /// </summary>
        /// <param name="messageKey">Message Key</param>
        public WorkspaceMessageSinkAttribute(string messageKey)
        {
            MessageKey = messageKey;
        }
    }
}

using task3.PBXPart;

namespace task3.CompanyPart.DB.ContractPart
{
    internal class TerminalItem
    {
        /// <summary>
        /// ID 
        /// </summary>
        internal int Id { get; private set; } = 0;

        /// <summary>
        /// CTOR
        /// </summary>
        internal TerminalItem(TerminalBase terminal)
        {
            this.Id = terminal.Number;
        }

    }
}

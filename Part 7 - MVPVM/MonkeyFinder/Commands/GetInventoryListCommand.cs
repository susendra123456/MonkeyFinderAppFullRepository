﻿#pragma warning disable CA1416

namespace MonkeyFinder.Commands
{
    /// <summary>
    /// We'll reuse the GetListCommand providing the button text used in view
    /// </summary>
    public class GetInventoryListCommand : GetListCommand
	{
		public GetInventoryListCommand(IInventoryDataService service) : base(service) 
		{
			MatchButtonText = AppConstants.GetInventoryButtonText;
		}
	}
}

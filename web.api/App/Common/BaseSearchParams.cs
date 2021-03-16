using System;

namespace OD_Stat.Modules.CommonModulesHelpings
{
    public abstract class BaseSearchParams
    {
        private readonly int _page = 1;
        private readonly int _take = 1;

        public int Page
        {
            get => _page;
            set
            {
                if (value < 1) throw new ArgumentException("Page must be larger than '1'");
            }
        }

        public int Take
        {
            get => _take;
            set
            {
                if (value < 1) throw new ArgumentException("Page must be larger than '1'");
            }
        }
    }
}
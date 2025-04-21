namespace Budget.API
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Incomes
        {
            private const string Base = $"{ApiBase}/incomes";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }

        public static class Expenses
        {
            private const string Base = $"{ApiBase}/expenses";

            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Templates.Test
{
    public class MvcTests : PuppeteerTestsBase
    {
        public MvcTests(ITestOutputHelper output)
            : base(output)
        {
        }

        [Theory]
        [InlineData(null)]
        [InlineData("F#")]
        private async Task MvcTemplate_NoAuthImpl(string languageOverride)
            => await MvcTemplateBase(languageOverride: languageOverride);

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task MvcTemplate_IndividualAuth(bool useLocalDb)
            => await MvcTemplateBase(auth: IndividualAuth, useLocalDb: useLocalDb);

        private async Task MvcTemplateBase(
            string languageOverride = null,
            string auth = null,
            bool noHttps = false,
            bool useLocalDb = false)
            => await TemplateBase(
                "mvc",
                httpPort: 5002,
                httpsPort: 5003,
                languageOverride,
                auth,
                noHttps,
                useLocalDb);
    }
}

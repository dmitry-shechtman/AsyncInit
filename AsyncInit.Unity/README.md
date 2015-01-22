AsyncInit Unity Dependency Injection
====================================

Adds support for asynchronously initialized types to Unity Container.

Usage
-----

0. Install `Ditto.AsyncInit.Unity`:

        Install-Package Ditto.AsyncInit.Unity

1. Define the interface:

        interface IUniversalAnswerService
        {
            int Answer { get; }
        }

2. Implement it, deriving from an appopriate `AsyncInitBase` or `CancelableAsyncInitBase` _(recommended)_:

        using Ditto.AsyncInit;

        class UniversalAnswerService : CancelableAsyncInitBase<UniversalAnswerService>, IUniversalAnswerService
        {
            private UniversalAnswerService()
                : base(null)
            {
            }

            protected override async Task InitAsync(CancellationToken cancellationToken)
            {
                await Task.Delay(TimeSpan.FromDays(7500000 * 365.25), cancellationToken);
                Answer = 42;
            }

            public int Answer { get; private set; }
        }

2. Register the mapping with the container:

        using Ditto.AsyncInit.Unity;

        container.RegisterAsyncType<IUniversalAnswerService, UniversalAnswerService>(new ContainerControlledLifetimeManager());

3. Resolve the interface:

        using Ditto.AsyncInit.Unity;

        var service = await container.ResolveAsync<IUniversalAnswerService>(cancellationToken);
        var answer = service.Answer;

**Done!** See the project wiki for advanced usage scenarios.

Notice
------

   Copyright © Dmitry Shechtman 2014-2015

   Licensed under the Apache License, Version 2.0 (the "License").

   You may obtain a copy of the License at
   http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.

Links
-----

* [Code](https://github.com/dmitry-shechtman/AsyncInit)
* [Wiki](https://github.com/dmitry-shechtman/AsyncInit/wiki)
* [Blog](https://shecht.wordpress.com/category/asyncactivator/)
* [NuGet](https://nuget.org/packages/Ditto.AsyncInit.Unity)

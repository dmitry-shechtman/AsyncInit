AsyncInit
=========

A generic implementation of the asynchronous factory pattern.

Usage
-----

0. Install `Ditto.AsyncInit`:

        Install-Package Ditto.AsyncInit

1. Determine the types of the initialization arguments (if any), e.g. `IProgress<long>`.

2. Derive from the corresponding `AsyncInitBase` or `CancelableAsyncInitBase` _(recommended)_, specifying your class as the first generic type argument:

        using Ditto.AsyncInit;

        class UniversalAnswerService : CancelableAsyncInitBase<UniversalAnswerService, IProgress<long>>
        {
            public int Answer { get; private set; }
        }

3. Implement a private parameterless constructor, passing `null` as parameter to `base`:

        private UniversalAnswerService()
            : base(null)
        {
        }

4. Override `InitAsync()`:

        protected override async Task InitAsync(IProgress<long> progress, CancellationToken cancellationToken)
        {
            await Task.Delay(TimeSpan.FromDays(7500000 * 365.25), cancellationToken);
            Answer = 42;
        }

**Done!** Your class may now be consumed asynchronously:

    var service = await UniversalAnswerService.Create(progress, cancellationToken);
    var answer = service.Answer;

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
* [NuGet](https://nuget.org/packages/Ditto.AsyncInit)

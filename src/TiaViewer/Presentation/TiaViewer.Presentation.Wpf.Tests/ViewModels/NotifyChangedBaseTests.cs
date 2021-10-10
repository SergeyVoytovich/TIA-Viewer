using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using FluentAssertions;
using Moq;
using TiaViewer.Presentation.Wpf.ViewModels;
using Xunit;

namespace TiaViewer.Presentation.Wpf.Tests.ViewModels
{
    public class NotifyChangedBaseTests
    {
        [Fact]
        public void Get()
        {
            // Prepare
            var p1 = "p1";
            var p2 = "p2";
            var v1 = "v1";
            var properties = new ConcurrentDictionary<string, object>(new List<KeyValuePair<string, object>> { new(p1, v1) });
            var notifyChanged = new Mock<NotifyChangedBase>(properties) { CallBase = true };

            // Action
            var actual1 = notifyChanged.Object.Get<string>(p1);
            var actual2 = notifyChanged.Object.Get<string>(p2);

            // Asserts
            actual1.Should().Be(v1);
            actual2.Should().BeNull();
        }

        [Fact]
        public void Set()
        {
            // Prepare
            var p1 = "p1";
            var p2 = "p2";
            var v1 = "v1";
            var v11 = "v11";
            var v2 = "v2";
            var properties = new ConcurrentDictionary<string, object>(new List<KeyValuePair<string, object>> { new(p1, v1) });
            var notifyChanged = new Mock<NotifyChangedBase>(properties) { CallBase = true };
            var raised = new Dictionary<string, int>();
            notifyChanged.Object.PropertyChanged += (_, args) =>
            {
                if (args.PropertyName != null)
                {
                    raised[args.PropertyName] = raised.TryGetValue(args.PropertyName, out var count) ? count + 1 : 1;
                }
            };

            // Action
            notifyChanged.Object.Set(v1, p1);
            notifyChanged.Object.Set(v2, p2);
            notifyChanged.Object.Set(v11, p1);

            // Asserts
            properties.Should().Match<ConcurrentDictionary<string, object>>(
                props => properties.ContainsKey(p1)
                         && string.Equals((string)props[p1], v11, StringComparison.OrdinalIgnoreCase));
            properties.Should().Match<ConcurrentDictionary<string, object>>(
                props => properties.ContainsKey(p2)
                         && string.Equals((string)props[p2], v2, StringComparison.OrdinalIgnoreCase));
            raised.Should()
                .Match<IDictionary<string, int>>(dict => dict.ContainsKey(p1) && raised[p1] == 1)
                .And.Match<IDictionary<string, int>>(dict => dict.ContainsKey(p2) && raised[p2] == 1)
                ;
        }
    }
}

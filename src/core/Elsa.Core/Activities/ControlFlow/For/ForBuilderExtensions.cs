using System;
using Elsa.Builders;
using Elsa.Services.Models;

// ReSharper disable once CheckNamespace
namespace Elsa.Activities.ControlFlow
{
    public static class ForBuilderExtensions
    {
        public static IActivityBuilder For(this IBuilder builder, Action<ISetupActivity<For>> setup, Action<IOutcomeBuilder> iterate) => builder.Then(setup, branch => iterate(branch.When(OutcomeNames.Iterate)));

        public static IActivityBuilder For(
            this IBuilder builder,
            Func<ActivityExecutionContext, long> start,
            Func<ActivityExecutionContext, long> end,
            Func<ActivityExecutionContext, long> step,
            Action<IOutcomeBuilder> iterate,
            Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Step, step)
                    .Set(x => x.Operator, op),
                iterate);

        public static IActivityBuilder For(this IBuilder builder, Func<long> start, Func<long> end, Func<long> step, Action<IOutcomeBuilder> iterate, Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Step, step)
                    .Set(x => x.Operator, op),
                iterate);

        public static IActivityBuilder For(this IBuilder builder, long start, long end, long step, Action<IOutcomeBuilder> iterate, Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Step, step)
                    .Set(x => x.Operator, op),
                iterate);

        public static IActivityBuilder For(this IBuilder builder, Func<ActivityExecutionContext, long> start, Func<ActivityExecutionContext, long> end, Action<IOutcomeBuilder> iterate, Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Operator, op),
                iterate);

        public static IActivityBuilder For(this IBuilder builder, Func<long> start, Func<long> end, Action<IOutcomeBuilder> iterate, Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Operator, op),
                iterate);

        public static IActivityBuilder For(this IBuilder builder, long start, long end, Action<IOutcomeBuilder> iterate, Operator op = Operator.LessThan) =>
            builder.For(
                activity => activity
                    .Set(x => x.Start, start)
                    .Set(x => x.End, end)
                    .Set(x => x.Operator, op),
                iterate);
    }
}
// using MassTransit;
// using Microsoft.FeatureManagement;

using MassTransit;
using Microsoft.FeatureManagement;
using Ordering.Application.Extensions;

namespace Ordering.Application.Orders.EventHandlers.Domain;
public class OrderCreatedEventHandler
    ( ILogger<OrderCreatedEventHandler> logger, IPublishEndpoint publishEndpoint, IFeatureManager featureManager)
    : INotificationHandler<OrderCreatedEvent>
{
    public  async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event handled: {DomainEvent}", domainEvent.GetType().Name);

        if (await featureManager.IsEnabledAsync("OrderFullfilment"))
        {
            var orderCreatedIntegrationEvent = domainEvent.order.ToOrderDto();
            await publishEndpoint.Publish(orderCreatedIntegrationEvent, cancellationToken);
        }
       
    }
}
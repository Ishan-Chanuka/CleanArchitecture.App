﻿using Domain.Primitives;
using MediatR;

namespace Application.Abstractions.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}

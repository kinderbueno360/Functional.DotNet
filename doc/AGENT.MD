# `Functional.DotNet` Agent Documentation

## Overview

In functional programming, an **agent** is a construct used for managing state and message processing in a controlled and side-effect-free manner. Agents encapsulate state and behavior, processing messages and optionally responding to them, while maintaining immutability and functional purity.

Agents in `Functional.DotNet` provide a way to handle asynchronous and stateful computations in a functional style. They are particularly useful in scenarios where state needs to be isolated and manipulated in a thread-safe manner.

## When to Use Agents

Use agents in scenarios where you need to:
- Manage state asynchronously and safely in a multi-threaded environment.
- Process a series of messages or tasks, with each message potentially altering the state.
- Create a system of components that communicate via message passing, avoiding direct manipulation of shared state.

## Key Agent Types

### StatelessAgent

- **Purpose**: Processes messages without maintaining any internal state.
- **Usage**: Suitable for scenarios where you need to handle messages or perform actions that don't require state tracking.
- **Key Methods**:
  - `Tell`: Accepts a message for processing.
- **Usage Example**:

```csharp
var agent = Agent.Start<string>(msg => Console.WriteLine(msg));
agent.Tell("Hello, Agent!");
```

### StatefulAgent

- **Purpose**: Maintains a mutable state that can be altered by incoming messages.
- **Usage**: Ideal for scenarios where the state needs to be updated in response to messages.
- **Key Methods**:
  - `Tell`: Accepts a message and updates the state based on the message.
- **Usage Example**:

```csharp
var agent = Agent.Start<int, string>(0, (state, msg) => state + 1);
agent.Tell("Increment");
```

### StatefulTwoWayAgent

- **Purpose**: Similar to `StatefulAgent`, but also capable of providing a response to each processed message.
- **Usage**: Use in situations where you need to maintain state and also require a response from the agent for each message.
- **Key Methods**:
  - `Tell`: Sends a message and receives a reply asynchronously.
- **Usage Example**:

```csharp
var agent = Agent.Start<int, string, string>(0, (state, msg) => (state + 1, $"Processed: {msg}"));
var reply = await agent.Tell("Hello");
```

## Creating Agents

- Use `Agent.Start` static methods to create instances of agents.
- Specify the message type, state type (if applicable), and processing logic.

## Summary

Agents in `Functional.DotNet` provide a robust and functional way to handle state and message processing, offering a clear and expressive approach to building systems with isolated state and asynchronous processing capabilities. They are instrumental in creating reactive and concurrent applications in a functional style within the .NET environment.

<div align="center">

# 🚀 Trading Platform

### Enterprise Algorithmic Trading Platform

**DDD • Clean Architecture • CQRS • Event Driven • .NET**

---

![.NET](https://img.shields.io/badge/.NET-9-purple)
![Architecture](https://img.shields.io/badge/Architecture-Clean-blue)
![DDD](https://img.shields.io/badge/DDD-Enterprise-success)
![CQRS](https://img.shields.io/badge/CQRS-Enabled-orange)
![License](https://img.shields.io/badge/license-MIT-green)

</div>

---

# Overview

Trading Platform is an enterprise-grade algorithmic trading system designed for Forex and Cryptocurrency markets.

The project is **not a broker** and **not an exchange**.

Instead, it provides a complete trading engine capable of connecting to multiple brokers such as:

- MetaTrader 5
- Binance
- Bybit
- OKX
- Interactive Brokers
- Future Broker Integrations

The goal is to build a reusable trading core that can execute manual, semi-automatic and fully automated trading strategies.

---

# Project Goals

The system is designed around five major principles.

- Domain Driven Design
- Clean Architecture
- CQRS
- Event Driven Architecture
- Broker Independence

The business logic must never depend on a specific broker implementation.

Everything inside the Domain should be reusable regardless of the execution provider.

---

# Architecture

```
                Broker APIs
       MT5 / Binance / Bybit / OKX
                     │
                     ▼
          Infrastructure Layer
                     │
        --------------------------
        │                        │
 Command Side               Query Side
        │                        │
        ▼                        ▼
 Application Services (CQRS)
                     │
                     ▼
              Domain Model
                     │
                     ▼
              Domain Events
```

---

# Project Structure

```
Trading.Core.Domain
│
├── Accounts
├── Orders
├── Positions
├── Trades
├── Portfolio
├── Strategies
├── Indicators
├── RiskManagement
├── Symbols
└── Market

Trading.Core.Contracts

Trading.Core.RequestResponse

Trading.Core.ApplicationService

Trading.Infrastructure

Trading.Api
```

---

# Current Progress

## Domain

- ✅ Accounts
- ✅ Orders
- ✅ Positions
- ✅ Trades
- ✅ Portfolio
- ✅ Strategies
- 🚧 Indicators
- ⏳ Risk Management
- ⏳ Symbols
- ⏳ Market

---

## Application Layer

Implemented using CQRS.

### Commands

- Create
- Update
- Delete
- Activate
- Deactivate
- Trading Operations

### Queries

- Paging
- Sorting
- Filtering
- Detail Queries

---

## Infrastructure

Planned

- Entity Framework Core
- Repository Pattern
- Broker SDK Integrations
- Message Bus
- Background Services
- Caching

---

## API

Planned

- REST API
- Authentication
- Authorization
- Swagger
- SignalR
- WebSocket Streaming

---

# Domain Modules

## Account

Represents a trading account.

Responsibilities

- Balance
- Margin
- Equity
- Leverage
- Account Status

---

## Order

Represents a broker order.

Supports

- Market Orders
- Pending Orders
- Stop Loss
- Take Profit
- Partial Fill
- Cancel
- Reject

---

## Position

Represents an opened market position.

Supports

- Partial Close
- Break Even
- Trailing Stop
- Liquidation
- Profit Calculation

---

## Trade

Represents a completed trade.

Stores

- Entry
- Exit
- Commission
- Swap
- Profit
- Duration

---

## Portfolio

Represents account statistics.

Includes

- Balance
- Equity
- Floating Profit
- Realized Profit
- Drawdown

---

## Strategy

Trading strategy definition.

Supports

- Enable / Disable
- Start / Stop
- Parameters
- Risk Settings

---

## Indicator

Technical indicators.

Examples

- RSI
- EMA
- SMA
- ATR
- MACD
- Bollinger Bands

---

# Design Principles

The project follows strict DDD principles.

```
Presentation

↓

Application

↓

Domain

↓

Infrastructure
```

Dependencies always point inward.

The Domain never depends on Infrastructure.

---

# CQRS

Commands modify data.

Queries never modify data.

Every Aggregate has

- Commands
- CommandHandlers
- Queries
- QueryHandlers
- Validators
- Repositories

---

# Event Driven Design

Aggregates publish domain events.

Examples

```
AccountCreated

OrderFilled

TradeClosed

PositionOpened

PortfolioUpdated

StrategyStarted

IndicatorUpdated
```

Future versions will allow asynchronous event processing.

---

# Broker Independence

The trading engine never communicates directly with MT5 or Binance.

Instead, broker adapters implement common interfaces.

```
ITradingBroker

IBrokerMarketData

IBrokerExecution

IBrokerAccount
```

Switching brokers should require zero changes in business logic.

---

# Future Roadmap

## Core

- Risk Management
- Symbol Engine
- Market Module
- Price Feed

---

## Infrastructure

- Entity Framework
- Redis
- RabbitMQ
- Hangfire

---

## Trading

- Strategy Runner
- Backtesting
- Optimization
- Paper Trading
- Live Trading

---

## AI

Future plans include AI-assisted trading.

Possible integrations

- Machine Learning
- Pattern Recognition
- Strategy Optimization
- Signal Classification

---

# Technology Stack

- .NET
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Redis
- RabbitMQ
- FluentValidation
- Clean Architecture
- DDD
- CQRS

---

# Philosophy

The purpose of this project is not merely to execute trades.

It is intended to become a reusable enterprise trading platform capable of supporting multiple brokers, multiple strategies, and multiple markets through a single, extensible domain model.

Every feature is designed with scalability, maintainability and long-term evolution in mind.

---

# License

MIT License

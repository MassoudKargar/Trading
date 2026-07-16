# Trading System Architecture

This folder contains the architecture documentation for the **Trading** platform.

The project is designed using **Domain Driven Design (DDD)**, **Clean Architecture**, **CQRS**, **Repository Pattern**, **Event Driven Architecture**, and supports multiple trading brokers such as **MetaTrader 5**, **Binance**, **Bybit**, and **OKX**.

---

# Architecture Documents

| File | Description |
|------|-------------|
| 01-System-Architecture.drawio | High-level system architecture |
| 02-Domain-Model.drawio | Domain Driven Design model and aggregates |
| 03-Database-ERD.drawio | Database Entity Relationship Diagram |
| 04-CQRS.drawio | CQRS command/query architecture |
| 05-Sequence-Order.drawio | Order execution sequence |
| 06-Sequence-Position.drawio | Position lifecycle sequence |
| 07-Strategy-Flow.drawio | Strategy execution pipeline |
| 08-Risk-Flow.drawio | Risk management workflow |
| 09-Broker-Architecture.drawio | Broker abstraction and integration |
| 10-Deployment.drawio | Production deployment architecture |

---

# Project Layers

```
Presentation
│
├── REST API
├── SignalR
└── gRPC

↓

Application

↓

Domain

↓

Infrastructure

↓

External Brokers
```

---

# Core Domains

```
Account
Portfolio
Position
Order
Trade
Strategy
Indicator
RiskProfile
Symbol
Tick
Candle
OrderBook
```

---

# Technologies

- .NET 9
- ASP.NET Core
- Entity Framework Core
- SQL Server
- MediatR
- FluentValidation
- SignalR
- Redis
- RabbitMQ (Future)
- Docker
- Kubernetes (Future)

---

# Design Patterns

- Domain Driven Design (DDD)
- Clean Architecture
- CQRS
- Repository Pattern
- Unit Of Work
- Factory Pattern
- Strategy Pattern
- Adapter Pattern
- Dependency Injection
- Domain Events
- Event Driven Architecture

---

# Broker Support

Current architecture supports:

- MetaTrader 5
- Binance
- Bybit
- OKX

Additional brokers can be added by implementing the `IBrokerAdapter` interface.

---

# Trading Flow

```
Market Data

↓

Indicators

↓

Strategy

↓

Risk Management

↓

Order

↓

Broker

↓

Position

↓

Trade

↓

Portfolio

↓

Account
```

---

# CQRS Flow

### Command Side

```
API

↓

Command

↓

Validation

↓

Command Handler

↓

Repository

↓

Aggregate

↓

Domain Events

↓

Database
```

### Query Side

```
API

↓

Query

↓

Query Handler

↓

Query Repository

↓

DTO
```

---

# Folder Structure

```
docs/
└── architecture/
    ├── README.md
    ├── 01-System-Architecture.drawio
    ├── 02-Domain-Model.drawio
    ├── 03-Database-ERD.drawio
    ├── 04-CQRS.drawio
    ├── 05-Sequence-Order.drawio
    ├── 06-Sequence-Position.drawio
    ├── 07-Strategy-Flow.drawio
    ├── 08-Risk-Flow.drawio
    ├── 09-Broker-Architecture.drawio
    └── 10-Deployment.drawio
```

---

# Future Improvements

- Event Bus Integration
- Distributed Cache
- High Availability
- Horizontal Scaling
- Multi-Tenant Support
- Strategy Marketplace
- AI Signal Engine
- Backtesting Engine
- Portfolio Optimization
- Risk Analytics
- Monitoring & Observability

---

# License

This project is intended for educational and commercial trading platform development.

---

**Author**

Massoud Kargar

Software Engineer

Trading Platform Architecture (DDD + CQRS + Clean Architecture)

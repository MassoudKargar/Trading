# Repository Instructions

## Scope

These instructions apply to the entire repository.

## Project Context

This is a .NET trading platform using Domain Driven Design, Clean Architecture, CQRS, and event-driven patterns. Keep broker-specific concerns out of the domain model.

## Architecture Rules

- Keep `Trading.Core.Domain` free of infrastructure, persistence, broker SDK, HTTP, messaging, and framework-specific dependencies.
- Put use-case orchestration and CQRS handlers in `Trading.Core.ApplicationService`.
- Put DTOs, requests, responses, and contracts in the existing contracts/request-response projects.
- Put EF Core, Redis, messaging, broker integrations, and other external adapters under `src/2.Infrastructure`.
- Put API and background worker entry points under `src/3.Endpoints`.
- Put tests under `src/4.Tests`.

## Coding Guidelines

- Preserve existing namespaces, folder structure, and naming conventions.
- Prefer small, focused changes that address the root cause.
- Do not introduce cross-layer references that violate Clean Architecture boundaries.
- Avoid broker-specific names or assumptions in domain entities, value objects, and domain services.
- Keep domain behavior inside domain types where practical; avoid anemic domain changes.
- Use async APIs for I/O-bound infrastructure and endpoint work.
- Do not add license headers or broad formatting-only changes unless explicitly requested.

## Validation

- Build with `dotnet build Trading.sln` after code changes when practical.
- Run targeted tests from `src/4.Tests/Trading.Tests` when modifying behavior covered by tests.
- If validation cannot be run, state the reason and the exact command that should be run.

## Documentation

- Update `README.md` or files under `docs` when changing architecture, setup, public behavior, or operational expectations.
- Keep documentation concise and aligned with the current implementation rather than future intent.

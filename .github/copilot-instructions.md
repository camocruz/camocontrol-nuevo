# Copilot Instructions

## General Guidelines
- First general instruction
- Second general instruction

## Code Style
- Use specific formatting rules
- Follow naming conventions

## Project-Specific Rules
- The project 'App.ApiClient.CS' will be used as a client library and must not contain UI startup code or a Program.cs with Application.Run; the WinForms project 'camocontrol' must reference App.ApiClient.CS and be responsible for registering and building the DI container and starting the application. Prefer registering DI services in the WinForms project of the solution or enable `<UseWindowsForms>true</UseWindowsForms>` if UI is needed in this project.
- El proyecto App.ApiClient.CS debe permanecer como librería de consulta (Class Library) y no debe compilarse ni configurarse como proyecto de arranque. Evitar incluir Program.cs, __UseWindowsForms__, o cualquier código de inicio; responsabilizar al proyecto WinForms 'camocontrol' de registrar servicios DI y arrancar la aplicación.
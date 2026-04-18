# SimpleConsoleAIChat

Minimal .NET console chat client built on `Microsoft.Agents.AI.OpenAI`.

The application starts a single chat session, reads prompts from standard input, and streams model output back to the terminal.

## Requirements

- .NET SDK 10.0
- An OpenAI API key exposed as `OPENAI_API_KEY`

## Project Layout

```text
SimpleConsoleAIChat/
	README.md
	SimpleConsoleAIChat/
		SimpleConsoleAIChat.slnx
		SimpleConsoleAIChat.Console/
			Program.cs
			SimpleConsoleAIChat.Console.csproj
```

## Configure

Set the API key before running the app.

### macOS or Linux

```bash
export OPENAI_API_KEY="your-api-key"
```

### Windows PowerShell

```powershell
$env:OPENAI_API_KEY = "your-api-key"
```

## Build

From the repository root:

```bash
dotnet build SimpleConsoleAIChat/SimpleConsoleAIChat.slnx
```

## Run

```bash
dotnet run --project SimpleConsoleAIChat/SimpleConsoleAIChat.Console
```

## Current Behavior

- Uses the `gpt-4.1-mini` model.
- Creates one agent named `Assistant` with the instruction `You are a helpful assistant.`
- Reuses a single chat session for the lifetime of the process.
- Streams responses to the console as tokens arrive.
- Runs in an infinite input loop until the process is stopped.

Example interaction:

```text
You> Explain dependency injection in one paragraph.
AI(gpt-4.1-mini)> Dependency injection is a design pattern where...
```

To exit, stop the process with `Ctrl+C`.

## Notes

- The application throws at startup if `OPENAI_API_KEY` is not set.
- The model name and assistant instructions are currently hard-coded in `Program.cs`.

## License

This project is licensed under the MIT License. See `LICENSE` for details.

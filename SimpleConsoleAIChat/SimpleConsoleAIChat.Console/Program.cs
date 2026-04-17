using OpenAI;
using OpenAI.Responses;
using OpenAI.Chat;

var apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY")
             ?? throw new InvalidOperationException("Set OPENAI_API_KEY environment variable.");

var model = "gpt-4.1-mini";

var agent = new OpenAIClient($"{apiKey}")
    .GetChatClient(model: model)
    .AsAIAgent(name: "Assistant", instructions: "You are a helpful assistant.");

var session = await agent.CreateSessionAsync();

while (true)
{
    Console.Write("You> ");
    var input = Console.ReadLine()!;
    Console.Write($"AI({model})> ");
    
    await foreach (var chunk in agent.RunStreamingAsync(input, session))
        Console.Write(chunk);
    Console.WriteLine("\n");
}
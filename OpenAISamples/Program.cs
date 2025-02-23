using System.Runtime.CompilerServices;
using Azure;  
using Azure.AI.OpenAI;
using OpenAI.Chat;

public class AzureOpenAISample
{
    private string endpoint = "https://openai-dem.openai.azure.com/";
    private string apiKey = "7PY6GYLBpKYd022bPk3BE1Dahe29SqBXsUAYGlSFnWFXFUvzNGmcJQQJ99BBACYeBjFXJ3w3AAABACOGbS5c";

    private static void Main()
    {
        AzureOpenAISample client = new AzureOpenAISample();
        client.CreateChatCompletion();
    }

    private void CreateChatCompletion()
    {
        var client = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

        ChatClient chatClient = client.GetChatClient("gpt-4");

        var message = new List<ChatMessage>()
        {
            new SystemChatMessage(Console.ReadLine())
        };

        ChatCompletion completion = chatClient.CompleteChat(message);
        Console.WriteLine(completion.Content.FirstOrDefault()?.Text);
        return;
    }

}
using System;
using Microsoft.AspNetCore.SignalR;

namespace GameStore.Api;

public class TestClass
{
    public string? Name { get; set; }
    public int MyProperty { get; set; }

    public TestClass()
    {

    }

    public bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    //Method to call a real REST API
    public async Task<string> CallRestApiAsync(string url)
    {
        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    
}

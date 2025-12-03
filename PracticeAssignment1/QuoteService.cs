using Practice_Assignment1.Services;
using Practice_Assignment1.Models;


public class QuoteService : IQuoteService
{
    private readonly List<Quote> _quotes;
    private readonly Random _random = new Random();

    public QuoteService()
    {
        _quotes = new List<Quote>
        {
            new Quote { Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs" },
            new Quote { Text = "In the end, we will remember not the words of our enemies, but the silence of our friends.", Author = "Martin Luther King Jr" },
            new Quote { Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill" },
            new Quote { Text = "Be yourself; everyone else is already taken.", Author = "Oscar Wilde" },
            new Quote { Text = "You miss 100% of the shots you don’t take.", Author = "Wayne Gretzky" },
            new Quote { Text = "In three words I can sum up everything I’ve learned about life: it goes on.", Author = "Robert Frost" },
            new Quote { Text = "Do not go where the path may lead, go instead where there is no path and leave a trail.", Author = "Ralph Waldo Emerson" },
            new Quote { Text = "It is never too late to be what you might have been.", Author = "George Eliot" },
            new Quote { Text = "The only limit to our realization of tomorrow is our doubts of today.", Author = "Franklin D. Roosevelt" },
            new Quote { Text = "The best way to predict the future is to invent it.", Author = "Alan Kay" }

        };
    }

    public Quote GetRandomQuote()
    {
        Random rnd = new Random();

        // Generating a random integer between 0 and the number of items in the List
        int rndNum = rnd.Next(_quotes.Count);
        return _quotes[rndNum];
    }
}

using EntityFNotes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace EntityFNotes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new DataContext();
        }
    }
}
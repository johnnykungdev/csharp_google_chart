using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
// useing fileIO
using Microsoft.VisualBasic.FileIO;
using CsvHelper;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using System;
using System.IO;
using System.Linq;
using week3_lab.Models;
using Google.DataTable.Net.Wrapper;
using System.Text.Json;

namespace week3_lab.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(){
    }

    // private List<Student> GetStudentsData() {
    //     using (var streamReader = new StreamReader(@"./students.csv")) 
    //     {
    //         using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
    //         {
    //             var records = csvReader.GetRecords<Student>().ToList();
    //             return records;
    //         }
    //     }
    // }
}

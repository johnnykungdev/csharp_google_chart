using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using week3_lab.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.DataTable.Net.Wrapper;
using System.Text.Json;

namespace week3_lab.Pages {
    public class ChartDataModel: PageModel {
        private readonly ILogger<ChartDataModel> _logger;

        public ChartDataModel(ILogger<ChartDataModel> logger)
        {
            _logger = logger;
        }
            
        public ContentResult OnGet()
        {
            Student[] students = GetStudentsData();
            //aggregation
            var data = students.GroupBy(_ => _.School)
            .Select(g => new {
                Name = g.Key,
                Count = g.Count()
            })
            .OrderByDescending(cp => cp.Count)
            .ToList();
            
            var dt = new Google.DataTable.Net.Wrapper.DataTable();
            dt.AddColumn(new Column(ColumnType.String, "Name", "Name"));
            dt.AddColumn(new Column(ColumnType.Number, "Count", "Count"));
            

            foreach (var item in data) {
                Row r = dt.NewRow();
                r.AddCellRange(new Cell[] {
                    new Cell(item.Name),
                    new Cell(item.Count)
                });
                dt.AddRow(r);
            }
            return Content(dt.GetJson());
        }

        private Student[] GetStudentsData() {
            string path = Directory.GetCurrentDirectory();
            string combined = Path.Combine(path, "students.csv");
            // "./students.csv"
            using (var streamReader = new StreamReader(@$"{combined}")) 
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvReader.GetRecords<Student>().ToArray();
                    return records;
                }
            }
        }
    }
}


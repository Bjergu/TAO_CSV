using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

class CSVRecord
{
    private Dictionary<string, int> columns;
    private string[] values;
    public CSVRecord(Dictionary<string, int> columns, string[] values)
    {
        this.columns = columns;
        this.values = values;
    }

    public string GetValue(string columnName)
    {
        if (!columns.ContainsKey(columnName)) throw new KeyNotFoundException("CSV column name not found!");
        return values[columns[columnName]];
    }

    public string this[string columnName]
    {
        get => GetValue(columnName);
    }
}

class CSVTable
{
    Dictionary<string, int> columnMapping = new Dictionary<string, int>();
    string[][] values;
    public string[] Headers { get; private set; }
    public int NumColumns { get; private set; }
    public int NumRecords { get; private set; }

    public CSVTable(string content, bool hasHeaders, char valueSeparator = ',', char rowSeparator = ';')
    {
        // Split into records
        string[] rows = content.Split(rowSeparator);
        // Store the number of records (minus one if first row contains column names)
        int numRecords = hasHeaders ? rows.Length - 1 : rows.Length;
        int numColumns = rows[0].Split(valueSeparator).Length;
        NumRecords = numRecords;
        NumColumns = numColumns;


        if (hasHeaders)
        {
            // If has headers, store them in a string array
            Headers = rows[0].Split(valueSeparator);
        }
        else
        {
            // If not, store column name as a number (0 - NumColumns-1)
            Headers = new string[numColumns];
            for (int i = 0; i < numColumns; i++) Headers[i] = "Col_" + i.ToString();
        }

        // Remove whitespaces and store the header names in a dictionary mapping to column indices
        for (int headerIndex = 0; headerIndex < numColumns; headerIndex++)
        {
            Headers[headerIndex] = Headers[headerIndex].Trim();
            columnMapping.Add(Headers[headerIndex], headerIndex);
        }

        // Initialise the array
        values = new string[numRecords][];

        // Store each record in the array
        for (int rowIndex = hasHeaders ? 1 : 0; rowIndex < rows.Length; rowIndex++)
        {
            string record = rows[rowIndex];
            // Split values 
            string[] rowValues = record.Split(valueSeparator);
            // Get correct index to start at 0 when indexing the 'values' array
            int valuesRowIndex = hasHeaders ? rowIndex - 1 : rowIndex;
            values[valuesRowIndex] = new string[NumColumns];

            // Store each value (column) in the array
            for (int columnIndex = 0; columnIndex < numColumns; columnIndex++)
            {
                values[valuesRowIndex][columnIndex] = rowValues[columnIndex];
            }
        }
    }

    public string GetValue(int rowIndex, string columnName)
    {
        if (!columnMapping.ContainsKey(columnName)) throw new KeyNotFoundException("CSV column name not found!");
        if (rowIndex >= NumRecords) throw new IndexOutOfRangeException("CSV record index out of range!");
        return values[rowIndex][columnMapping[columnName]];
    }

    public string GetValue(int rowIndex, int columnIndex)
    {
        if (columnIndex >= NumColumns) throw new IndexOutOfRangeException("CSV column index out of range!");
        if (rowIndex >= NumRecords) throw new IndexOutOfRangeException("CSV record index out of range!");
        return values[rowIndex][columnIndex];
    }

    public CSVRecord GetRecord(int index)
    {
        return new CSVRecord(columnMapping, values[index]);
    }

    public List<T> ConvertCSVToModel<T>(Func<CSVRecord, T> converter)
    {
        List<T> convertedValues = new List<T>();
        for (int rowIndex = 0; rowIndex < NumRecords; rowIndex++)
        {
            CSVRecord record = GetRecord(rowIndex);
            convertedValues.Add(converter(record));
        }
        return convertedValues;
    }

}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duplicati.BackupExplorer.UI.Views
{
    using System;
    using Avalonia.Data.Converters;
    using System.Globalization;
    using Avalonia;
    using Duplicati.BackupExplorer.LocalDatabaseAccess.Model;
    using System.IO;
    using Avalonia.Media.Immutable;

    public class FileSizeSharedConverter : IMultiValueConverter
    {
        object? IMultiValueConverter.Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Any(x => x is UnsetValueType)) return false;

            // Ensure all bindings are provided and attached to correct target type
            if (values?.Count != 2 || !targetType.IsAssignableFrom(typeof(string)))
                throw new NotSupportedException();

            var part2 = FileSizeConverter.CalculateNumeric((long)values[1]);
            var part1 = FileSizeConverter.CalculateNumeric((long)values[0], part2.Item2);
            return String.Format("{0:0.##}/{1:0.##} {2}", part1.Item1, part2.Item1, part2.Item2);
        }
    }

}
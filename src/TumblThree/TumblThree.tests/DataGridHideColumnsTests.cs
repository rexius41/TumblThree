using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace TumblThree.Presentation.Controls.Tests
{
    [TestClass]
    public class DataGridHideColumnsTests
    {
        [TestMethod]
        public void GetHideColumnsHeader_ShouldReturnCorrectValue()
        {
     
            var dataGrid = new DataGrid();
            var expected = new object();
            DataGridHideColumns.SetHideColumnsHeader(dataGrid, expected);

 
            var actual = DataGridHideColumns.GetHideColumnsHeader(dataGrid);

    
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetHideColumnsHeader_ShouldSetCorrectValue()
        {
 
            var dataGrid = new DataGrid();
            var value = new object();

            DataGridHideColumns.SetHideColumnsHeader(dataGrid, value);
            var actual = DataGridHideColumns.GetHideColumnsHeader(dataGrid);

     
            Assert.AreEqual(value, actual);
        }

    }
}

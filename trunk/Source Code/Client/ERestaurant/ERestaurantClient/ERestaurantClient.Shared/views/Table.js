
var ORDERED_STATUS = "1";
var EMPTY_STATUS = "0";

ERestaurantClient.Table = function (params) {
    $(".dx-scrollable-content-horizontal").attr('style', 'left:0px;');
    
    var viewModel = {
        dSource: tileViewData,
        GetBackground: function (e) {
            if (e === ORDERED_STATUS) {
                return "url('/images/table.jpg')";
            }
            else {
                return "url('/images/table_ordered.png')";
            }
        },
        //dSource: ERestaurantClient.db.sampleData.Categories,
        onItemClick: function (e) {
            var categoryName = e.itemData.name;
            alert(categoryName);
        }
    };
    return viewModel;
};
scrollBarVisible = ko.observable(false);
var tileViewData = [
      { name: "Alabama", tableStatus: "1", population: 4822023, area: 135765 },
      { name: "Alaska", tableStatus: "Juneau", population: 731449, area: 1717854 },
      { name: "Arizona", tableStatus: "Phoenix", population: 6553255, area: 295254 },
      { name: "Arkansas", tableStatus: "Little Rock", population: 2949131, area: 137002 },
      { name: "California", tableStatus: "Sacramento", population: 38041430, area: 423970 },
      { name: "Colorado", tableStatus: "Denver", population: 5187582, area: 269602 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
       { name: "Alabama", tableStatus: "1", population: 4822023, area: 135765 },
      { name: "Alaska", tableStatus: "Juneau", population: 731449, area: 1717854 },
      { name: "Arizona", tableStatus: "Phoenix", population: 6553255, area: 295254 },
      { name: "Arkansas", tableStatus: "Little Rock", population: 2949131, area: 137002 },
      { name: "California", tableStatus: "Sacramento", population: 38041430, area: 423970 },
      { name: "Colorado", tableStatus: "Denver", population: 5187582, area: 269602 },
       { name: "Alabama", tableStatus: "1", population: 4822023, area: 135765 },
      { name: "Alaska", tableStatus: "Juneau", population: 731449, area: 1717854 },
      { name: "Arizona", tableStatus: "1", population: 6553255, area: 295254 },
      { name: "Arkansas", tableStatus: "Little Rock", population: 2949131, area: 137002 },
      { name: "California", tableStatus: "Sacramento", population: 38041430, area: 423970 },
      { name: "Colorado", tableStatus: "Denver", population: 5187582, area: 269602 },
       { name: "Alabama", tableStatus: "1", population: 4822023, area: 135765 },
      { name: "Alaska", tableStatus: "Juneau", population: 731449, area: 1717854 },
      { name: "Arizona", tableStatus: "1", population: 6553255, area: 295254 },
      { name: "Arkansas", tableStatus: "Little Rock", population: 2949131, area: 137002 },
      { name: "California", tableStatus: "Sacramento", population: 38041430, area: 423970 },
      { name: "Colorado", tableStatus: "Denver", population: 5187582, area: 269602 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Colorado", tableStatus: "Denver", population: 5187582, area: 269602 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "1", population: 3590347, area: 14356 },
      { name: "Connecticut", tableStatus: "Hartford", population: 3590347, area: 14356 }
];
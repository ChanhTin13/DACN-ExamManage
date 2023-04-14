 
var xValues = ["Kỹ thuật lập trình", "TA1", "TA3", "CSDL", "LTDT"];
var yValues = [225, 429, 424, 224, 245];
var barColors = ["red", "green","blue","orange","brown"];

new Chart("myChart", {
  type: "bar",
  data: {
    labels: xValues,
    datasets: [{
      backgroundColor: barColors,
      data: yValues
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: "Số lượng bài trên trung bình của từng môn"
    }
  }
}); 


    var xValues = [ "7-8.5","8.5-10", "10", "5-6.9", "dưới 5"];
    var yValues = [55, 49, 5, 24, 15];
    var barColors = [
      "#b91d47",
      "#00aba9",
      "#2b5797",
      "#e8c3b9",
      "#1e7145"
    ];
    
    new Chart("PieChart", {
      type: "pie",
      data: {
        labels: xValues, 
        datasets: [{
          backgroundColor: barColors,
          data: yValues
        }]
      },
      options: {
        title: {
          display: true,
          text: "Tỉ lệ điểm của môn có nhiều điểm trên TB"
        }
      }
    }); 
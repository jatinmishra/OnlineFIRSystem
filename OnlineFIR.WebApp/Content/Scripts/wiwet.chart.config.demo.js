 /*

WIWET.com - ASP.NET Templates

Wildomar Template

*/

 var chartSession = [
        {
          value: 36,
          color:"#2078dc",
        },
        {
          value: 64,
          color: "#e9e9e9",
        },
        {
          value: 44,
          color: "#FDB45C",
        }

      ];
      var ctx1 = document.getElementById("chart-session").getContext("2d");
      window.myDoughnut = new Chart(ctx1).Doughnut(chartSession, {
        responsive : true,
        animationEasing: "linear",
        datasetStrokeWidth: 1,
        percentageInnerCutout: 85,
        segmentStrokeWidth : 0,
        showTooltips: false
      });


      // line chart 
     var randomScalingFactor = function(){ return Math.round(Math.random()*100)};
    var lineChartData = {
      labels : ["January","February","March","April","May","June","July"],
      datasets : [
        {
          label: "My First dataset",
          fillColor : "rgba(220,220,220,0.2)",
          strokeColor : "rgba(220,220,220,1)",
          pointColor : "rgba(220,220,220,1)",
          pointStrokeColor : "#fff",
          pointHighlightFill : "#fff",
          pointHighlightStroke : "rgba(220,220,220,1)",
          data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
        },
        {
          label: "My Second dataset",
          fillColor : "rgba(151,187,205,0.2)",
          strokeColor : "rgba(151,187,205,1)",
          pointColor : "rgba(151,187,205,1)",
          pointStrokeColor : "#fff",
          pointHighlightFill : "#fff",
          pointHighlightStroke : "rgba(151,187,205,1)",
          data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
        }
      ]

    }

    var ctx2 = document.getElementById("chart-activity").getContext("2d");
    window.myLine = new Chart(ctx2).Line(lineChartData, {
      responsive: true,
      // scaleGridLineColor : "rgba(86,142,225,1)",
      // animation : false,
      datasetStrokeWidth: 1
    });


      // bar chart
      var randomScalingFactor = function(){ return Math.round(Math.random()*100)};

  var barChartData = {
    labels : ["January","February","March","April","May","June","July"],
    datasets : [
      {
        fillColor : "rgba(220,220,220,0.5)",
        strokeColor : "rgba(220,220,220,0.8)",
        highlightFill: "rgba(220,220,220,0.75)",
        highlightStroke: "rgba(220,220,220,1)",
        data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
      },
      {
        fillColor : "rgba(151,187,205,0.5)",
        strokeColor : "rgba(151,187,205,0.8)",
        highlightFill : "rgba(151,187,205,0.75)",
        highlightStroke : "rgba(151,187,205,1)",
        data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
      }
    ]

  }

  // radar chart
    var polarData = [
        {
          value: 300,
          color:"#F7464A",
          highlight: "#FF5A5E",
          label: "Red"
        },
        {
          value: 50,
          color: "#46BFBD",
          highlight: "#5AD3D1",
          label: "Green"
        },
        {
          value: 100,
          color: "#FDB45C",
          highlight: "#FFC870",
          label: "Yellow"
        },
        {
          value: 40,
          color: "#949FB1",
          highlight: "#A8B3C5",
          label: "Grey"
        },
        {
          value: 120,
          color: "#4D5360",
          highlight: "#616774",
          label: "Dark Grey"
        }

      ];

      window.onload = function(){

        var ctx3 = document.getElementById("chart-bar").getContext("2d");
    window.myBar = new Chart(ctx3).Bar(barChartData, {
      responsive : true
    });

        var ctx4 = document.getElementById("chart-radar").getContext("2d");
        window.myPolarArea = new Chart(ctx4).PolarArea(polarData, {
          responsive:true
        });
      };


    
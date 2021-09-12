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
        }

      ];
      var ctx = document.getElementById("chart-session").getContext("2d");
      window.myDoughnut = new Chart(ctx).Doughnut(chartSession, {
        responsive : true,
        animationEasing: "linear",
        datasetStrokeWidth: 1,
        percentageInnerCutout: 85,
        segmentStrokeWidth : 0,
        showTooltips: false
      });

   var chartUsers = [
        {
          value: 40,
          color:"#2078dc",
        },
        {
          value: 60,
          color: "#e9e9e9",
        }

      ];
      var ctx = document.getElementById("chart-users").getContext("2d");
      window.myDoughnut = new Chart(ctx).Doughnut(chartUsers, {
        responsive : true,
        animationEasing: "linear",
        datasetStrokeWidth: 0,
        percentageInnerCutout: 85,
        segmentStrokeWidth : 0,
        showTooltips: false
      });

  var chartDuration = [
        {
          value: 45,
          color:"#2078dc",
        },
        {
          value: 55,
          color: "#e9e9e9",
        }

      ];
      var ctx = document.getElementById("chart-duration").getContext("2d");
      window.myDoughnut = new Chart(ctx).Doughnut(chartDuration, {
        responsive : true,
        animationEasing: "linear",
        datasetStrokeWidth: 1,
        percentageInnerCutout: 85,
        segmentStrokeWidth : 0,
        showTooltips: false
      });

   var chartPageViews = [
        {
          value: 35,
          color:"#2078dc",
          segmentStrokeWidth: 0,
          animateRotate : false,
          label: "Red"
        },
        {
          value: 65,
          color: "#e9e9e9",
        }

      ];
      var ctx = document.getElementById("chart-pageviews").getContext("2d");
      window.myDoughnut = new Chart(ctx).Doughnut(chartPageViews, {
        responsive : true,
        animationEasing: "linear",
        datasetStrokeWidth: 0,
        percentageInnerCutout: 85,
        segmentStrokeWidth: 0,
        showTooltips: false
      });


      // line chart activity
      var randomScalingFactor = function(){ return Math.round(Math.random()*80)};
      var lineChartData = {
      labels : ["1","2","3","4","5","6","7","8"],
      datasets : [
        {
          label: "Activity dataset",
          fillColor : "rgba(0,0,0,0)",
          strokeColor : "white",
          pointColor : "transparent",
          pointStrokeColor : "rgba(0,0,0,0)",
          pointHighlightFill : "rgba(0,0,0,0)",
          pointHighlightStroke : "rgba(0,0,0,0)",
          data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
        }
      ]

    }

    var ctx = document.getElementById("chart-activity").getContext("2d");
    window.myLine = new Chart(ctx).Line(lineChartData, {
      responsive: true,
      scaleGridLineColor : "rgba(86,142,225,1)",
      // animation : false,
      datasetStrokeWidth: 1,
      scaleFontColor: "#FFFFFF"
    });

    // line chart visits
      var randomScalingFactor = function(){ return Math.round(Math.random()*80)};
      var lineChartData1 = {
      labels : ["1","2","3","4","5","6","7","8","9"],
      datasets : [
        {
          label: "Activity dataset",
          fillColor : "rgba(0,0,0,0)",
          strokeColor : "#6fc080",
          pointColor : "#6fc080",
          pointStrokeColor : "rgba(0,0,0,0)",
          pointHighlightFill : "rgba(0,0,0,0)",
          pointHighlightStroke : "rgba(0,0,0,0)",
          data : [randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor(),randomScalingFactor()]
        }
      ]

    }

    var ctx = document.getElementById("chart-visits").getContext("2d");
    window.myLine = new Chart(ctx).Line(lineChartData1, {
      responsive: true,
      scaleGridLineColor : "rgba(0,0,0,0)",
      datasetStrokeWidth: 2,
      scaleFontColor: "rgba(0,0,0,0)",
      scaleLineColor: "rgba(0,0,0,0)"
    });
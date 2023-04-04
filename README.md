This MAUI app is the template created by Visual Studio. It contains a button and WebView control which pounts to URL that loads a blank chart upon start.


            <Button
                x:Name="btnExecuteJS"
                Text="Execute Javascript in WebView"
                SemanticProperties.Hint="Execute JS in WebView"
                Clicked="btnExecuteJSClicked"
                HorizontalOptions="Center" />

            <WebView x:Name="webViewFID"
                     Source="https://digital.fidelity.com/stgw/digital/fidchart/consumers/atp/0.0.4/atp-chart.html"
                     WidthRequest="700"
                     HeightRequest="600" />

The button handler in the code behind makes a JS call via WebView's eval function to display the chart

	private void btnExecuteJSClicked(object sender, EventArgs e)
	{

		// this JS call will display a chart for AAPL in the webview.
		// The chart tool works in the browser on both windows and mac, but not in the webview on mac.

		string chartOptions = """ { "header":false,"isAuthenticated":true,"symbol":"AAPL","isPartial":false,"displays":{ "default":"candle" },"timeframe":{ "default":"TODAY","items":["TODAY","2D","5D","10D","1M","3M","6M","YTD","1Y","2Y","5Y","10Y","MAX"] },"frequency":{ "default":"5m","items":["1m","5m","10m","15m","30m","1H","4H","1D","1W","1M","1Q","1Y"] },"study":false,"toggle":{ "savedChartsMenu":true,"patternEventsMenu":false,"openOrders":false }} """;
		string datasourceOptions = """ { "env":"dev", "productid":"chartplatform", "realtime":false, "uuid":"d94167ee-1b27-11dc-ab78-ac196951aa77" } """;

		webViewFID.Eval($"displayInitialChart({chartOptions},{datasourceOptions})");

		/*
		 to test the chart JS directly in the browser, execute these JS in Safari Developer Tools console:
		
		var chartOptions = {"header":false,"isAuthenticated":true,"symbol":"AAPL","isPartial":false,"displays":{"default":"candle"},"timeframe":{"default":"TODAY","items":["TODAY","2D","5D","10D","1M","3M","6M","YTD","1Y","2Y","5Y","10Y","MAX"]},"frequency":{"default":"5m","items":["1m","5m","10m","15m","30m","1H","4H","1D","1W","1M","1Q","1Y"]},"study":false,"toggle":{"savedChartsMenu":true,"patternEventsMenu":false,"openOrders":false}};
		var datasourceOptions = {"env":"dev","productid":"chartplatform","realtime":false,"uuid":"d94167ee-1b27-11dc-ab78-ac196951aa77"};
		displayInitialChart(chartOptions,datasourceOptions);

		 */

	}

In the comment block there is the JS version of the code that can be directly executed in the Developers Tool console, for testing purpose

The issue: this app works on windows, but does not work on Mac (after the chart is displayed, the chart tools do not work e.g. draw functions don't work)

On Mac, if this blank chart is loaded in Safari and then executing the JS code, the chart tools work properly.

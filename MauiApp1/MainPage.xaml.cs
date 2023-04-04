namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}


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
}


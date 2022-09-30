using AsynchronousDemo;

var demo = new HttpClientDemo();

demo.CallTo_WebService();
await demo.CallTo_WebServiceAsync();

// _____________________________

var demo1 = new FileAccessDemo();

demo1.ReadFile();
demo1.WriteFile();

await demo1.ReadFileAsync();
await demo1.WriteFileAsync();
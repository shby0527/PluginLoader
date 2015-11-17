# PluginLoader
Mono Plugin Loader    <br> 
通用的.Net 插件加载类 <br>
实现一个标记接口`IPlugin`，并且标注插件的信息特性 `PluginInfoAttribute` <br>
就可使用该插件加载器加载并使用，无需修改源代码 <br>
## How to use?  
需要计算出一个`SHA256`的字符串来作为`GUID`<br>
选择产于计算的属性，推荐使用 `<作者名>[插件名]{版本号}`<br>
该GUID为了方便识别是否是同一个插件<br>
使用时需要有一个实现了插件类接口的父类，防止不同系统间的插件互相加载<br>

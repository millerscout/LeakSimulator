# LeakSimulator

A Project to generate memory leak.

# how use it?

Configure this project to an iis or just run, on my environment i've configured to use procdump binded to the pool

and request to the url:
```http://localhost:2121/home/leak/21```
this leak will generate around 2GBs and stops after that.

right below there's a guide to identift the leak's origin.

# Required

[procmon](https://docs.microsoft.com/en-us/sysinternals/downloads/procdump) - to generate dumps.
```
procdump -w w3wp -mm -ma -m 1000 -n 2
```
## using DebugDiag analysis
 [install](https://techcommunity.microsoft.com/t5/iis-support-blog/debugdiag-2-update-3-rtw/ba-p/457874)

## using windbg
[windows sdk](https://developer.microsoft.com/en-us/windows/downloads/sdk-archive/)
[wdk](https://docs.microsoft.com/pt-br/windows-hardware/drivers/download-the-wdk)
[sos + documentation](https://docs.microsoft.com/en-us/dotnet/framework/tools/sos-dll-sos-debugging-extension) 

[windbg](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools) -  [early guide for windbg](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-managed-code)
[Psscor4, windbg's extension](microsoft.com/en-us/download/details.aspx?id=21255)

[caching](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/symbol-path)

WIP:
forked list: https://gist.github.com/millerscout/cebceb9ff389dc6e47af911df3a3f93a
``` 
!sym noisy
.sympath srv*c:\symbols*http://msdl.microsoft.com/download/symbols
.load C:\tools\procdump\Psscor4\x86\x86\psscor4.dll --x86
.load C:\tools\procdump\Psscor4\amd64\amd64\psscor4 --x64
.load C:\Windows\Microsoft.NET\Framework\v4.0.30319\SOS.dll --x86
.load C:\Windows\Microsoft.NET\Framework64\v4.0.30319\sos.dll --x64
.loadby sos clr ---not required from my tests.
.reload
.chain -- check if chain is configured accordingly
```

get overview from addresses
```
 !address -summary
```

Run the command, the last type has the most size in memory.
```!dumpheap ```
<p align="center">
        <a href ="https://github.com/millerscout/LeakSimulator/raw/master/images/heapstat.png">
         <img src="https://github.com/millerscout/LeakSimulator/raw/master/images/heapstat.png" alt="Buy me a coffee" style="max-width:100%;">
     </a>
</p>
Run the type to get the addresses, the first column is the address.
order: Address               MT     Size
```!DumpHeap -type {type}```

get the greater address available and run 

```!gcroot -all {address}```

<p align="center">
        <a href ="https://github.com/millerscout/LeakSimulator/raw/master/images/gcroot.png">
         <img src="https://github.com/millerscout/LeakSimulator/raw/master/images/gcroot.png" alt="Buy me a coffee" style="max-width:100%;">
     </a>
</p>

-----other commands:

```!heap -l```

```!heap -stat -h 00000193c1bc0000```

```!heap -flt s 4b0000 ```

```!dumpheap -stat ```



<p align="center">
        <a href ="https://www.buymeacoffee.com/gR79MHU">
         <img src="https://github.com/millerscout/Kenshi-Mod-Manager/raw/master/Donation.png" alt="Buy me a coffee" style="max-width:100%;">
     </a>
</p>

# References:

https://stackoverflow.com/questions/23811168/where-can-i-find-net-4-0-sos-dll

https://www.linkedin.com/pulse/resolving-memory-leaks-using-windbg-jon-krupa

https://stackoverflow.com/questions/33738306/heap-stat-h-doesnt-show-allocations

https://community.osr.com/discussion/286573/detecting-memory-leaks-with-windbg

https://gist.github.com/nickfloyd/a332462f85ac32372c74

https://www.sysnative.com/forums/threads/which-windbg-command-to-locate-heap-block-number-or-address.29311/

https://dlaa.me/blog/post/9471347

https://stackoverflow.com/questions/55240025/using-windbg-to-find-memory-leak-issue-in-asp-net-application

http://thinkexception.blogspot.com/2010/06/tool-to-bompare-two-windbg-dumpheap.html

https://github.com/millerscout/book-of-reference/blob/master/CSharp.md

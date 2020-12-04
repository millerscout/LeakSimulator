# LeakSimulator

A Project to generate memory leak.


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

[caching](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/symbol-path)

WIP:
forked list: https://gist.github.com/millerscout/cebceb9ff389dc6e47af911df3a3f93a
``` 
!sym noisy
.sympath srv*c:\symbols*http://msdl.microsoft.com/download/symbols
.load C:\tools\procdump\Psscor4\x86\x86\psscor4.dll --x86
.load C:\tools\procdump\Psscor4\amd64\amd64\psscor4 --x64
.load C:\Windows\Microsoft.NET\Framework\v4.0.30319\SOS.dll   --32x
.load C:\Windows\Microsoft.NET\Framework64\v4.0.30319\sos.dll --64x
.loadby sos clr --not working

.reload

!dumpheap

```

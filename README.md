# LeakSimulator

A Project to generate memory leak.


# Required

(procmon)[https://docs.microsoft.com/en-us/sysinternals/downloads/procdump] - to generate dumps.
```
procdump -w w3wp -mm -ma -m 1000 -n 2
```

(windows sdk)[https://developer.microsoft.com/en-us/windows/downloads/sdk-archive/]
(windbg)[https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugger-download-tools] (early guide for windbg)[https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-managed-code]
(caching)[https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/symbol-path]

WIP:
``` 
!sym noisy
.sympath srv*c:\symbols*http://msdl.microsoft.com/download/symbols
.reload
.cordll -ve -u -l
!analyse -v

```

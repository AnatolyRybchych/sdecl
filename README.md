# sdecl
tool for searching for declarations in headr files

> [CommandManager](https://github.com/AnatolyRybchych/CommandManager)

```cmd
$ sdecl select test
stack select successful
$ sdecl stack dirs add "C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0" -r save
[
    Directory: "C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0" recursive
]
$ stack all find glClear
$ sdecl stack all find glClear
[
    WINGDIAPI void APIENTRY glClear (GLbitfield mask);
    WINGDIAPI void APIENTRY glClearAccum (GLfloat red, GLfloat green, GLfloat blue, GLfloat alpha);
    WINGDIAPI void APIENTRY glClearColor (GLclampf red, GLclampf green, GLclampf blue, GLclampf alpha);
    WINGDIAPI void APIENTRY glClearDepth (GLclampd depth);
    WINGDIAPI void APIENTRY glClearIndex (GLfloat c);
    WINGDIAPI void APIENTRY glClearStencil (GLint s);
]
$ sdecl stack all
[
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\LICENSE.txt
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\base.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.AI.MachineLearning.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.AI.MachineLearning.Preview.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.Activation.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.AppExtensions.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.Appointments.AppointmentsProvider.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.Appointments.DataProvider.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.Appointments.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.AppService.h
    File: C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0\cppwinrt\winrt\Windows.ApplicationModel.Background.h
...
```

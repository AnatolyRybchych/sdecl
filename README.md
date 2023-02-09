# sdecl
tool for searching for declarations in header files

> [CommandManager](https://github.com/AnatolyRybchych/CommandManager)

> Commands
```txt
$ sdecl commands
[
    commands    required[],     variadic[]      - returns list of commands for this type
    stack       required[],     variadic[]      - selects last selected stack
    select      required[String:stack name],    variadic[]      - selects stack using name
    delete      required[String:stack name],    variadic[]      - deletes stack by name
    list        required[],     variadic[]      - returns list of sdecl stacks
]
$ sdecl stack commands
[
    commands    required[],     variadic[]      - returns list of commands for this type
    dirs        required[],     variadic[]      - returns collection of directories, of current stack
    files       required[],     variadic[]      - returns collection of files in current stack
    all required[],     variadic[]      - returns all file in stack
]
$ sdecl stack dirs commands
[
    commands    required[],     variadic[]      - returns list of commands for this type
    at  required[Int32:index],  variadic[]      - returns element in collection uisng id, id >= 0
    clear       required[],     variadic[]      - returns empty collection with same type
    add required[String:path],  variadic[Boolean:recursive]     - returns collection with new directory {path, -r(recursive, variadic)}
    save        required[],     variadic[]      - saves collection state
]

$ sdecl stack files commands
[
    commands    required[],     variadic[]      - returns list of commands for this type
    at  required[Int32:index],  variadic[]      - returns element in collection uisng id, id >= 0
    clear       required[],     variadic[]      - returns empty collection with same type
    add required[String:path],  variadic[]      - returns collection with new File{path}
    save        required[],     variadic[]      - saves collection state
    find        required[String:target],        variadic[Int32:lines before, Int32:lines after, Int32:max matches count]        - searching text in current stack files
    with        required[String:substring],     variadic[Boolean:name]  - returns subcollection where ( path or name if -n ) is contains substring
]
```
> Example
```txt
$ sdecl select test
stack select successful
$ sdecl list
[
    test
]
$ sdecl stack dirs add "C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0" -r save
[
    Directory: "C:\Program Files (x86)\Windows Kits\10\Include\10.0.19041.0" recursive
]
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

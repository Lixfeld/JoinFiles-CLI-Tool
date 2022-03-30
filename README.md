# JoinFiles-CLI-Tool
Simple .NET CLI tool for joining files

## Values and Options
```
  input-directory (pos. 0)           Required. Path of the directory with input files.

  output-file (pos. 1)               Required. Path for the output file including file extension.

  -a BOOL, --all-directories=BOOL    Includes the current directory and all its subdirectories in a search operation.

  --extension                        Filter the input files by extension.

  --separator-file                   Path of the file which should be used as a separator.

  -o BOOL, --overwrite=BOOL          Overwrite the output file, if it already exists.

  --skip=INT                         (Default: 0) Skip the first {count} files ordered by name.

  --take=NULLABLE<INT>               Take a maximum of {count} files.

  -v BOOL, --verbose=BOOL            Show verbose messaging.

  --help                             Display this help screen.

  --version                          Display version information.
```

## Package and Installation
[Official Documentation][1]  

**Commands for Developer PowerShell:**  
```
dotnet pack
dotnet tool install --global --add-source ./nupkg joinfiles.cli
dotnet tool uninstall -g joinfiles.cli
```

[1]: https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools 
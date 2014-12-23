@echo off

set OUTPUT_FOLDER=%~dp0Output
set OPT_FOLDER="%OUTPUT_FOLDER%\opt"
set OPTLIC_FOLDER="%OUTPUT_FOLDER%\license"
set OUTPUT_FOLDER="%OUTPUT_FOLDER%"

rem Clean-up output folder
if not exist %OUTPUT_FOLDER% (
    echo %OUTPUT_FOLDER% does not exist
)

if not exist %OPT_FOLDER% (
    echo %OPT_FOLDER% does not exist
)

if not exist %OPTLIC_FOLDER% (
    echo %OPTLIC_FOLDER% does not exist
)

rem Copy 
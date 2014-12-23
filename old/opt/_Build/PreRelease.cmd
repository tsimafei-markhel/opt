@echo off

set OUTPUT_FOLDER=%~dp0Output
set OPT_FOLDER="%OUTPUT_FOLDER%\opt"
set OPTLIC_FOLDER="%OUTPUT_FOLDER%\license"
set OUTPUT_FOLDER="%OUTPUT_FOLDER%"

rem Clean-up output folder
if exist %OUTPUT_FOLDER% (
    rmdir /s /q %OUTPUT_FOLDER%
)

rem Create folders to copy artefacts to
mkdir %OUTPUT_FOLDER%
mkdir %OPT_FOLDER%
mkdir %OPTLIC_FOLDER%
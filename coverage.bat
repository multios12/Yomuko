echo off

rem �e�X�g�c�[���̃p�X
set target_test=C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\ide\mstest.exe

rem �e�X�gDLL�p�X��
set unit_prj=.\UnitTest\bin\Debug\UnitTest.dll

rem �t�B���^
set filters=+[CLibrary]* -[CLibrary]CLibrary.Control. -[CLibrary]CLibrary.Form.* -[CLibrary]CLibrary.Properties.*

.\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:"%target_test%" -targetargs:" /testcontainer:%unit_prj%" -filter:"%filters%" -register:user

.\packages\ReportGenerator.2.4.5.0\tools\ReportGenerator.exe "-reports:results.xml" "-targetdir:.\coverage"

pause

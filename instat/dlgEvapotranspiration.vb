' R- Instat
' Copyright (C) 2015-2017
'
' This program is free software: you can redistribute it and/or modify
' it under the terms of the GNU General Public License as published by
' the Free Software Foundation, either version 3 of the License, or
' (at your option) any later version.
'
' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.
'
' You should have received a copy of the GNU General Public License 
' along with this program.  If not, see <http://www.gnu.org/licenses/>.

Imports instat
Imports instat.Translations

Public Class dlgEvapotranspiration
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = False
    Private clsETPenmanMonteith, clsHargreavesSamani, clsDataFunctionPM, clsDataFunctionHS, clsDataFunction, clsReadInputs, clsVector, clsMissingDataVector, clsVarnamesVectorPM, clsVarnamesVectorHS, clsLibraryEvap As New RFunction
    Private clsDayFunc, clsMonthFunc, clsMonthConvertFunc, clsYearFunc As New RFunction
    Private clsDailyOperatorPM, clsDailyOperatorHS As New ROperator

    Private Sub dlgdlgEvapotranspiration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bFirstload Then
            InitialiseDialog()
            bFirstload = False
        End If
        If bReset Then
            SetDefaults()
        End If
        SetRCodeForControls(bReset)
        bReset = False
        autoTranslate(Me)
        TestOKEnabled()
    End Sub

    Private Sub InitialiseDialog()
        ucrBase.clsRsyntax.iCallType = 2
        'ucrBase.iHelpTopicID = 510
        Dim dctInputCrops As New Dictionary(Of String, String)
        Dim dctInputTimeStep As New Dictionary(Of String, String)
        Dim dctInputSolar As New Dictionary(Of String, String)
        Dim dctInputMissingMethod As New Dictionary(Of String, String)

        ucrReceiverDate.SetMeAsReceiver()

        'receivers
        ucrReceiverDate.SetLinkedDisplayControl(lblDate)
        ucrReceiverTmax.SetLinkedDisplayControl(lblTmax)
        UcrReceiverTmin.SetLinkedDisplayControl(lblTmin)
        UcrReceiverHumidityMax.SetLinkedDisplayControl(lblHumidityMax)
        UcrReceiverHumidityMin.SetLinkedDisplayControl(lblHumidityMin)
        UcrReceiverRadiation.SetLinkedDisplayControl(lblRadiation)
        UcrReceiverWindSpeed.SetLinkedDisplayControl(lblWindSpeed)
        UcrInputSolar.SetLinkedDisplayControl(lblSolar)

        ucrReceiverDate.Selector = ucrSelectorEvaop
        ucrReceiverDate.SetParameter(New RParameter("x", 0))
        ucrReceiverDate.SetParameterIsRFunction()
        ucrReceiverDate.SetClimaticType("date")
        ucrReceiverDate.bAutoFill = True

        ucrReceiverTmax.Selector = ucrSelectorEvaop
        ucrReceiverTmax.SetParameter(New RParameter("Tmax", 3))
        ucrReceiverTmax.SetParameterIsRFunction()
        ucrReceiverTmax.SetClimaticType("temp_max")
        ucrReceiverTmax.bAutoFill = True

        UcrReceiverTmin.Selector = ucrSelectorEvaop
        UcrReceiverTmin.SetParameter(New RParameter("Tmin", 3))
        UcrReceiverTmin.SetParameterIsRFunction()
        UcrReceiverTmin.SetClimaticType("temp_min")
        UcrReceiverTmin.bAutoFill = True

        UcrReceiverHumidityMax.Selector = ucrSelectorEvaop
        UcrReceiverHumidityMax.SetParameter(New RParameter("RHmax", 4))
        UcrReceiverHumidityMax.SetParameterIsRFunction()
        'UcrReceiverHumidityMax.bAutoFill = True

        UcrReceiverHumidityMin.Selector = ucrSelectorEvaop
        UcrReceiverHumidityMin.SetParameter(New RParameter("RHmin", 5))
        UcrReceiverHumidityMin.SetParameterIsRFunction()
        'UcrReceiverHumidityMin.bAutoFill = True

        UcrReceiverRadiation.Selector = ucrSelectorEvaop
        UcrReceiverRadiation.SetParameter(New RParameter("Rs", 6))
        UcrReceiverRadiation.SetParameterIsRFunction()
        UcrReceiverRadiation.SetClimaticType("radiation")
        UcrReceiverRadiation.bAutoFill = True

        UcrReceiverWindSpeed.Selector = ucrSelectorEvaop
        UcrReceiverWindSpeed.SetParameter(New RParameter("u2", 7))
        UcrReceiverWindSpeed.SetParameterIsRFunction()
        UcrReceiverWindSpeed.SetClimaticType("wind_speed")
        UcrReceiverWindSpeed.bAutoFill = True

        UcrInputTimeStep.SetParameter(New RParameter("ts", 2))
        UcrInputTimeStep.SetRDefault(Chr(34) & "daily" & Chr(34))
        dctInputTimeStep.Add("daily", "daily")
        dctInputTimeStep.Add("monthly", "monthly")
        dctInputTimeStep.Add("annual", "annual")
        UcrInputTimeStep.SetItems(dctInputTimeStep)
        UcrInputTimeStep.SetDropDownStyleAsNonEditable()
        UcrInputTimeStep.SetLinkedDisplayControl(lblTimeStep)

        UcrInputSolar.SetParameter(New RParameter("solar", 3))
        UcrInputSolar.SetRDefault(Chr(34) & "sunshine hours" & Chr(34))
        dctInputSolar.Add("sunshine hours", "sunshine hours")
        dctInputSolar.Add("cloud", "cloud")
        dctInputSolar.Add("monthly precipitation", "monthly precipitation")
        UcrInputSolar.SetItems(dctInputSolar)
        UcrInputSolar.SetDropDownStyleAsNonEditable()

        UcrInputCrop.SetParameter(New RParameter("crops", 5))
        dctInputCrops.Add("short", "short")
        dctInputCrops.Add("tall", "tall")
        UcrInputCrop.SetItems(dctInputCrops)
        UcrInputCrop.SetRDefault(Chr(34) & "short" & Chr(34))
        UcrInputCrop.SetDropDownStyleAsNonEditable()
        UcrInputCrop.SetLinkedDisplayControl(lblCrop)

        UcrChkWind.SetParameter(New RParameter("wind", 4))
        UcrChkWind.SetText("Wind")
        UcrChkWind.SetValuesCheckedAndUnchecked(Chr(34) & "yes" & Chr(34), Chr(34) & "no" & Chr(34))
        UcrChkWind.SetRDefault(Chr(34) & "yes" & Chr(34))

        UcrChkSaveCSV.SetParameter(New RParameter("save.csv", 7))
        UcrChkSaveCSV.SetText("Save csv File")
        UcrChkSaveCSV.SetValuesCheckedAndUnchecked(Chr(34) & "yes" & Chr(34), Chr(34) & "no" & Chr(34))
        UcrChkSaveCSV.SetRDefault(Chr(34) & "no" & Chr(34))

        ' Missing Options 
        ucrChkInterpMissingDays.SetParameter(New RParameter("interp_missing_days"))
        ucrChkInterpMissingDays.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkInterpMissingDays.SetRDefault("FALSE")
        ucrChkInterpMissingDays.SetText("Interpolate Missing Days")

        ucrChkInterpMissingEntries.SetParameter(New RParameter("interp_missing_entries"))
        ucrChkInterpMissingEntries.SetValuesCheckedAndUnchecked("TRUE", "FALSE")
        ucrChkInterpMissingEntries.SetRDefault("FALSE")
        ucrChkInterpMissingEntries.SetText("Interpolate Missing Entries")

        ucrInputComboBoxMissingMethod.SetParameter(New RParameter("missing_method"))
        ucrInputComboBoxMissingMethod.SetItems({"NULL", Chr(34) & "monthly average" & Chr(34), Chr(34) & "seasonal average" & Chr(34), Chr(34) & "DoY average" & Chr(34), Chr(34) & "neighbouring average" & Chr(34)})
        ucrInputComboBoxMissingMethod.SetRDefault("NULL")
        ucrInputComboBoxMissingMethod.SetDropDownStyleAsNonEditable()
        dctInputMissingMethod.Add("NULL", "NULL")
        dctInputMissingMethod.Add("monthly average", "monthly average")
        dctInputMissingMethod.Add("seasonal average", "seasonal average")
        dctInputMissingMethod.Add("DoY average", "DoY average")
        dctInputMissingMethod.Add("neighbouring average", "neighbouring average")
        ucrInputComboBoxMissingMethod.SetItems(dctInputMissingMethod)

        ucrNudMaxMissingData.SetParameter(New RParameter("x", bNewIncludeArgumentName:=False))
        ucrNudMaxMissingDays.SetParameter(New RParameter("y", bNewIncludeArgumentName:=False))
        ucrNudMaxDurationMissingData.SetParameter(New RParameter("z", bNewIncludeArgumentName:=False))

        'ucrSave Date Column
        ucrNewColName.SetLabelText("New Column Name:")
        ucrNewColName.SetPrefix("Evapotranspiration")
        ucrNewColName.SetSaveTypeAsColumn()
        ucrNewColName.SetDataFrameSelector(ucrSelectorEvaop.ucrAvailableDataFrames)
        ucrNewColName.SetIsComboBox()
        ucrNewColName.SetAssignToBooleans(bTempAssignToIsPrefix:=True)

        'panel setting
        UcrPnlMethod.AddRadioButton(rdoPenmanMonteith)
        UcrPnlMethod.AddRadioButton(rdoHargreavesSamani)
        UcrPnlMethod.AddParameterPresentCondition(rdoPenmanMonteith, "ET.PenmanMonteith")
        UcrPnlMethod.AddParameterPresentCondition(rdoHargreavesSamani, "ET.HargreavesSamani")

        UcrPnlMethod.AddToLinkedControls(UcrInputCrop, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:="short")
        UcrPnlMethod.AddToLinkedControls(UcrInputSolar, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:="sunshine hours")
        UcrPnlMethod.AddToLinkedControls(UcrChkWind, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverHumidityMax, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverHumidityMin, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverRadiation, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverWindSpeed, {rdoPenmanMonteith}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True)
        UcrPnlMethod.AddToLinkedControls(UcrInputTimeStep, {rdoPenmanMonteith, rdoHargreavesSamani}, bNewLinkedAddRemoveParameter:=True, bNewLinkedHideIfParameterMissing:=True, bNewLinkedChangeToDefaultState:=True, objNewDefaultState:="daily")
    End Sub

    Private Sub SetDefaults()
        clsETPenmanMonteith = New RFunction
        clsHargreavesSamani = New RFunction
        clsDataFunctionPM = New RFunction
        clsDataFunctionHS = New RFunction
        clsDailyOperatorPM = New ROperator
        clsDailyOperatorHS = New ROperator
        clsReadInputs = New RFunction

        ucrSelectorEvaop.Reset()
        ucrNewColName.Reset()
        ucrReceiverDate.SetMeAsReceiver()

        UcrInputTimeStep.SetName(Chr(34) & "daily" & Chr(34))
        UcrInputSolar.SetName(Chr(34) & "sunshine hours" & Chr(34))
        UcrInputCrop.SetName(Chr(34) & "short" & Chr(34))
        ucrInputComboBoxMissingMethod.SetName("NULL")

        clsDataFunctionPM.SetRCommand("data.frame")
        clsDataFunctionHS.SetRCommand("data.frame")

        clsDayFunc.SetRCommand("day")
        clsDayFunc.SetPackageName("lubridate")

        clsMonthFunc.SetRCommand("month")
        clsMonthFunc.AddParameter("x", clsRFunctionParameter:=clsMonthConvertFunc, bIncludeArgumentName:=False)
        clsMonthFunc.SetPackageName("lubridate")

        clsMonthConvertFunc.SetRCommand("as.POSIXlt")
        clsMonthConvertFunc.AddParameter("format", Chr(34) & "%d/%m/%Y" & Chr(34))

        clsYearFunc.SetRCommand("year")
        clsYearFunc.SetPackageName("lubridate")

        clsLibraryEvap.SetRCommand("library")
        clsLibraryEvap.AddParameter("Evapotranspiration", "Evapotranspiration", bIncludeArgumentName:=False)
        ucrBase.clsRsyntax.AddToBeforeCodes(clsLibraryEvap, iPosition:=0)

        clsDataFunction.SetRCommand("data")
        clsDataFunction.AddParameter("constants", Chr(34) & "constants" & Chr(34), bIncludeArgumentName:=False)
        ucrBase.clsRsyntax.AddToBeforeCodes(clsDataFunction, iPosition:=1)

        clsReadInputs.SetRCommand("ReadInputs")
        clsReadInputs.AddParameter("constants", "constants", iPosition:=2, bIncludeArgumentName:=False)
        clsReadInputs.AddParameter("stopmissing", clsRFunctionParameter:=clsMissingDataVector, iPosition:=3)
        clsReadInputs.AddParameter("timestep", Chr(34) & "daily" & Chr(34), iPosition:=4)
        clsReadInputs.AddParameter("interp_missing_days", "FALSE", iPosition:=5)
        clsReadInputs.AddParameter("interp_missing_entries", "FALSE", iPosition:=6)
        clsReadInputs.AddParameter("interp_abnormal", "FALSE", iPosition:=7)
        clsReadInputs.AddParameter("missing_method", "NULL", iPosition:=8)
        clsReadInputs.AddParameter("abnormal_method", "NULL", iPosition:=9)

        clsVarnamesVectorPM.SetRCommand("c")
        clsVarnamesVectorPM.AddParameter("Tmax", Chr(34) & "Tmax" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorPM.AddParameter("Tmin", Chr(34) & "Tmin" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorPM.AddParameter("HRmax", Chr(34) & "HRmax" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorPM.AddParameter("HRmin", Chr(34) & "HRmin" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorPM.AddParameter("Rs", Chr(34) & "Rs" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorPM.AddParameter("u2", Chr(34) & "u2" & Chr(34), bIncludeArgumentName:=False)

        clsVarnamesVectorHS.SetRCommand("c")
        clsVarnamesVectorHS.AddParameter("Tmax", Chr(34) & "Tmax" & Chr(34), bIncludeArgumentName:=False)
        clsVarnamesVectorHS.AddParameter("Tmin", Chr(34) & "Tmin" & Chr(34), bIncludeArgumentName:=False)

        clsMissingDataVector.SetRCommand("c")

        clsVector.SetRCommand("c")

        clsETPenmanMonteith.SetPackageName("Evapotranspiration")
        clsHargreavesSamani.SetPackageName("Evapotranspiration")
        clsReadInputs.SetPackageName("Evapotranspiration")

        clsETPenmanMonteith.SetRCommand("ET.PenmanMonteith")
        clsETPenmanMonteith.AddParameter("data", clsRFunctionParameter:=clsReadInputs, iPosition:=0)
        clsETPenmanMonteith.AddParameter("constants", "constants", iPosition:=1, bIncludeArgumentName:=False)
        clsETPenmanMonteith.SetAssignTo("Penman_Monteith")
        clsETPenmanMonteith.AddParameter("ts", Chr(34) & "daily" & Chr(34), iPosition:=2)
        clsETPenmanMonteith.AddParameter("save.csv", Chr(34) & "no" & Chr(34))

        clsHargreavesSamani.SetRCommand("ET.HargreavesSamani")
        clsHargreavesSamani.AddParameter("data", clsRFunctionParameter:=clsReadInputs, iPosition:=0)
        clsHargreavesSamani.AddParameter("constants", "constants", iPosition:=1, bIncludeArgumentName:=False)
        clsHargreavesSamani.SetAssignTo("Hargreaves_Samani")
        clsHargreavesSamani.AddParameter("ts", Chr(34) & "daily" & Chr(34), iPosition:=2)
        clsHargreavesSamani.AddParameter("save.csv", Chr(34) & "no" & Chr(34))

        clsDailyOperatorPM.SetOperation("$")
        clsDailyOperatorPM.AddParameter("ET.PenmanMonteith", clsRFunctionParameter:=clsETPenmanMonteith, iPosition:=0)
        clsDailyOperatorPM.AddParameter("ET.Daily", strParameterValue:="ET.Daily", iPosition:=1)

        clsDailyOperatorHS.SetOperation("$")
        clsDailyOperatorHS.AddParameter("ET.HargreavesSamani", clsRFunctionParameter:=clsHargreavesSamani, iPosition:=0)
        clsDailyOperatorHS.AddParameter("ET.Daily", strParameterValue:="ET.Daily", iPosition:=1)

        ucrBase.clsRsyntax.SetAssignTo(strAssignToName:=ucrNewColName.GetText, strTempDataframe:=ucrSelectorEvaop.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempColumn:=ucrNewColName.GetText)
        ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorPM)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrReceiverDate.AddAdditionalCodeParameterPair(clsMonthConvertFunc, New RParameter("x", 0), iAdditionalPairNo:=1)
        ucrReceiverDate.AddAdditionalCodeParameterPair(clsYearFunc, New RParameter("x", 0), iAdditionalPairNo:=2)
        ucrReceiverTmax.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Tmax", 3), iAdditionalPairNo:=1)
        UcrReceiverTmin.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Tmin", 4), iAdditionalPairNo:=1)
        UcrInputTimeStep.AddAdditionalCodeParameterPair(clsHargreavesSamani, New RParameter("ts", 2), iAdditionalPairNo:=1)
        UcrChkSaveCSV.AddAdditionalCodeParameterPair(clsHargreavesSamani, New RParameter("save.csv", 4), iAdditionalPairNo:=1)

        UcrPnlMethod.SetRCode(ucrBase.clsRsyntax.clsBaseOperator, bReset)
        ucrReceiverDate.SetRCode(clsDayFunc, bReset)
        ucrReceiverTmax.SetRCode(clsDataFunctionPM, bReset)
        UcrReceiverTmin.SetRCode(clsDataFunctionPM, bReset)
        UcrReceiverHumidityMax.SetRCode(clsDataFunctionPM, bReset)
        UcrReceiverHumidityMin.SetRCode(clsDataFunctionPM, bReset)
        UcrReceiverRadiation.SetRCode(clsDataFunctionPM, bReset)
        UcrReceiverWindSpeed.SetRCode(clsDataFunctionPM, bReset)
        UcrInputTimeStep.SetRCode(clsETPenmanMonteith, bReset)
        UcrInputSolar.SetRCode(clsETPenmanMonteith, bReset)
        UcrInputCrop.SetRCode(clsETPenmanMonteith, bReset)
        UcrChkWind.SetRCode(clsETPenmanMonteith, bReset)
        UcrChkSaveCSV.SetRCode(clsETPenmanMonteith, bReset)
        ucrNewColName.SetRCode(ucrBase.clsRsyntax.clsBaseOperator, bReset)
        ucrNudMaxMissingData.SetRCode(clsMissingDataVector, bReset)
        ucrNudMaxMissingDays.SetRCode(clsMissingDataVector, bReset)
        ucrNudMaxDurationMissingData.SetRCode(clsMissingDataVector, bReset)
        ucrChkInterpMissingDays.SetRCode(clsReadInputs, bReset)
        ucrChkInterpMissingEntries.SetRCode(clsReadInputs, bReset)
        ucrInputComboBoxMissingMethod.SetRCode(clsReadInputs, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If rdoPenmanMonteith.Checked Then
            If ucrNewColName.IsComplete AndAlso Not ucrReceiverDate.IsEmpty() AndAlso Not ucrReceiverTmax.IsEmpty() AndAlso Not UcrReceiverTmin.IsEmpty() AndAlso Not UcrReceiverHumidityMax.IsEmpty() AndAlso Not UcrReceiverHumidityMin.IsEmpty() AndAlso Not UcrReceiverRadiation.IsEmpty() AndAlso Not UcrReceiverWindSpeed.IsEmpty() AndAlso Not UcrInputTimeStep.IsEmpty AndAlso Not UcrInputSolar.IsEmpty AndAlso Not UcrInputCrop.IsEmpty Then
                ucrBase.OKEnabled(True)
            Else
                ucrBase.OKEnabled(False)
            End If
        ElseIf rdoHargreavesSamani.Checked Then
            If ucrNewColName.IsComplete AndAlso Not ucrReceiverDate.IsEmpty() AndAlso Not ucrReceiverTmax.IsEmpty() AndAlso Not UcrReceiverTmin.IsEmpty() AndAlso Not UcrInputTimeStep.IsEmpty() Then
                ucrBase.OKEnabled(True)
            Else
                ucrBase.OKEnabled(False)
            End If
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub ucrBase_BeforeClickOk(sender As Object, e As EventArgs) Handles ucrBase.BeforeClickOk
        If rdoPenmanMonteith.Checked Then
            ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorPM)
        ElseIf rdoHargreavesSamani.Checked Then
            ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorHS)
        End If
    End Sub

    Private Sub ucrPnlMethod_ControlContentsChanged(ucrChangedControl As ucrCore) Handles UcrPnlMethod.ControlContentsChanged
        Method()
        TestOKEnabled()
    End Sub

    Private Sub ucrReceiverTmax_ControlValueChanged(ucrChangedControl As ucrCore) Handles UcrReceiverRadiation.ControlValueChanged, UcrReceiverHumidityMin.ControlValueChanged, UcrReceiverHumidityMax.ControlValueChanged, UcrReceiverTmin.ControlValueChanged, ucrReceiverTmax.ControlValueChanged, ucrReceiverDate.ControlValueChanged, UcrReceiverWindSpeed.ControlValueChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrInputTimeStep_ControlValueChanged(ucrChangedControl As ucrCore) Handles UcrInputTimeStep.ControlValueChanged, UcrInputSolar.ControlValueChanged, UcrInputCrop.ControlValueChanged, UcrInputSolar.ControlValueChanged, ucrInputComboBoxMissingMethod.ControlValueChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrNudMaxMissingData_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrNudMaxMissingData.ControlContentsChanged, ucrNudMaxDurationMissingData.ControlContentsChanged, ucrNudMaxMissingDays.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrNewColName_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrNewColName.ControlContentsChanged
        TestOKEnabled()
    End Sub

    Private Sub Method()
        If rdoPenmanMonteith.Checked Then
            clsReadInputs.AddParameter("varnames", clsRFunctionParameter:=clsVarnamesVectorPM, iPosition:=0)
            clsReadInputs.AddParameter("climatedata", clsRFunctionParameter:=clsDataFunctionPM, iPosition:=1)
            clsDataFunctionPM.AddParameter("Year", clsRFunctionParameter:=clsYearFunc)
            clsDataFunctionPM.AddParameter("Month", clsRFunctionParameter:=clsMonthFunc)
            clsDataFunctionPM.AddParameter("Day", clsRFunctionParameter:=clsDayFunc)
        ElseIf rdoHargreavesSamani.Checked Then
            clsReadInputs.AddParameter("varnames", clsRFunctionParameter:=clsVarnamesVectorHS, iPosition:=0)
            clsReadInputs.AddParameter("climatedata", clsRFunctionParameter:=clsDataFunctionHS, iPosition:=1)
            clsDataFunctionHS.AddParameter("Year", clsRFunctionParameter:=clsYearFunc)
            clsDataFunctionHS.AddParameter("Month", clsRFunctionParameter:=clsMonthFunc)
            clsDataFunctionHS.AddParameter("Day", clsRFunctionParameter:=clsDayFunc)
        End If
    End Sub
End Class



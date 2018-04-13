﻿' R- Instat
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

Imports instat.Translations

Public Class dlgEvapotranspiration
    Private bFirstload As Boolean = True
    Private bReset As Boolean = True
    Private bResetSubdialog As Boolean = False
    Private clsETPenmanMonteith, clsHargreavesSamani, clsDataFunctionPM, clsDataFunctionHS, clsReadInputs As New RFunction
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

        'panel setting
        UcrPnlMethod.AddRadioButton(rdoPenmanMonteith)
        UcrPnlMethod.AddRadioButton(rdoHargreavesSamani)
        UcrPnlMethod.AddFunctionNamesCondition(rdoPenmanMonteith, "ET.PenmanMonteith")
        UcrPnlMethod.AddFunctionNamesCondition(rdoHargreavesSamani, "ET.HargreavesSamani")
        UcrPnlMethod.AddToLinkedControls(UcrInputCrop, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrInputSolar, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrChkWind, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverHumidityMax, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverHumidityMin, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverRadiation, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)
        UcrPnlMethod.AddToLinkedControls(UcrReceiverWindSpeed, {rdoPenmanMonteith}, bNewLinkedHideIfParameterMissing:=True)

        'receivers
        ucrReceiverYear.SetLinkedDisplayControl(lblYear)
        ucrReceiverMonth.SetLinkedDisplayControl(lblMonth)
        ucrReceiverDay.SetLinkedDisplayControl(lblDay)
        ucrReceiverTmax.SetLinkedDisplayControl(lblTmax)
        UcrReceiverTmin.SetLinkedDisplayControl(lblTmin)
        UcrReceiverHumidityMax.SetLinkedDisplayControl(lblHumidityMax)
        UcrReceiverHumidityMin.SetLinkedDisplayControl(lblHumidityMin)
        UcrReceiverRadiation.SetLinkedDisplayControl(lblRadiation)
        UcrReceiverWindSpeed.SetLinkedDisplayControl(lblWindSpeed)
        UcrInputSolar.SetLinkedDisplayControl(lblSolar)
        UcrInputTimeStep.SetLinkedDisplayControl(lblTimeStep)

        ucrReceiverYear.Selector = ucrSelectorEvaop
        ucrReceiverYear.SetParameter(New RParameter("Year", 0))
        ucrReceiverYear.SetParameterIsRFunction()
        ucrReceiverYear.bAutoFill = True

        ucrReceiverMonth.Selector = ucrSelectorEvaop
        ucrReceiverMonth.SetParameter(New RParameter("Month", 1))
        ucrReceiverMonth.SetParameterIsRFunction()
        ucrReceiverMonth.bAutoFill = True

        ucrReceiverDay.Selector = ucrSelectorEvaop
        ucrReceiverDay.SetParameter(New RParameter("Day", 1))
        ucrReceiverDay.SetParameterIsRFunction()
        ucrReceiverDay.bAutoFill = True

        ucrReceiverTmax.Selector = ucrSelectorEvaop
        ucrReceiverTmax.SetParameter(New RParameter("Tmax", 3))
        ucrReceiverTmax.SetParameterIsRFunction()
        ucrReceiverTmax.bAutoFill = True

        UcrReceiverTmin.Selector = ucrSelectorEvaop
        UcrReceiverTmin.SetParameter(New RParameter("Tmin", 3))
        UcrReceiverTmin.SetParameterIsRFunction()
        UcrReceiverTmin.bAutoFill = True

        UcrReceiverHumidityMax.Selector = ucrSelectorEvaop
        UcrReceiverHumidityMax.SetParameter(New RParameter("RHmax", 4))
        UcrReceiverHumidityMax.SetParameterIsRFunction()
        UcrReceiverHumidityMax.bAutoFill = True

        UcrReceiverHumidityMin.Selector = ucrSelectorEvaop
        UcrReceiverHumidityMin.SetParameter(New RParameter("RHmin", 5))
        UcrReceiverHumidityMin.SetParameterIsRFunction()
        UcrReceiverHumidityMin.bAutoFill = True

        UcrReceiverRadiation.Selector = ucrSelectorEvaop
        UcrReceiverRadiation.SetParameter(New RParameter("Rs", 6))
        UcrReceiverRadiation.SetParameterIsRFunction()
        UcrReceiverRadiation.bAutoFill = True

        UcrReceiverWindSpeed.Selector = ucrSelectorEvaop
        UcrReceiverWindSpeed.SetParameter(New RParameter("u2", 7))
        UcrReceiverWindSpeed.SetParameterIsRFunction()
        UcrReceiverWindSpeed.bAutoFill = True

        UcrInputTimeStep.SetParameter(New RParameter("ts", 2))
        UcrInputTimeStep.SetItems({Chr(34) & "daily" & Chr(34), Chr(34) & "monthly" & Chr(34), Chr(34) & "annual" & Chr(34)})
        UcrInputTimeStep.SetRDefault(Chr(34) & "daily" & Chr(34))
        UcrInputTimeStep.SetDropDownStyleAsNonEditable()
        UcrInputTimeStep.SetLinkedDisplayControl(lblTimeStep)

        UcrInputSolar.SetParameter(New RParameter("solar", 3))
        UcrInputSolar.SetItems({Chr(34) & "sunshine hours" & Chr(34), Chr(34) & "cloud" & Chr(34), Chr(34) & "monthly precipitation" & Chr(34)})
        UcrInputSolar.SetRDefault(Chr(34) & "sunshine hours" & Chr(34))
        UcrInputSolar.SetDropDownStyleAsNonEditable()

        UcrInputCrop.SetParameter(New RParameter("crops", 5))
        UcrInputCrop.SetItems({Chr(34) & "short" & Chr(34), Chr(34) & "tall" & Chr(34)})
        UcrInputCrop.SetRDefault(Chr(34) & "short" & Chr(34))
        UcrInputCrop.SetDropDownStyleAsNonEditable()
        UcrInputCrop.SetLinkedDisplayControl(lblCrop)

        UcrChkWind.SetParameter(New RParameter("wind", 4))
        UcrChkWind.SetText("Wind")
        UcrChkWind.SetValuesCheckedAndUnchecked(Chr(34) & "yes" & Chr(34), Chr(34) & "no" & Chr(34))
        UcrChkWind.SetRDefault(Chr(34) & "yes" & Chr(34))

        UcrChkSaveCSV.SetParameter(New RParameter("save.csv", 7))
        UcrChkSaveCSV.SetText("Save .csv")
        UcrChkSaveCSV.SetValuesCheckedAndUnchecked(Chr(34) & "yes" & Chr(34), Chr(34) & "no" & Chr(34))
        UcrChkSaveCSV.SetRDefault("yes")

        'ucrSave Date Column
        UcrNewColumnName.SetPrefix("Evapotranspiration")
        UcrNewColumnName.SetSaveTypeAsColumn()
        UcrNewColumnName.SetDataFrameSelector(ucrSelectorEvaop.ucrAvailableDataFrames)
        UcrNewColumnName.SetIsComboBox()
        UcrNewColumnName.SetCheckBoxText("New Column Name:")
        'UcrNewColumnName.SetText("New Column Name:")

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
        ucrReceiverYear.SetMeAsReceiver()
        UcrNewColumnName.Reset()

        UcrInputTimeStep.SetName(Chr(34) & "daily" & Chr(34))
        UcrInputSolar.SetName(Chr(34) & "sunshine hours" & Chr(34))
        UcrInputCrop.SetName(Chr(34) & "short" & Chr(34))
        UcrChkWind.Checked = True
        UcrChkSaveCSV.Checked = True

        clsETPenmanMonteith.SetPackageName("Evapotranspiration")
        clsHargreavesSamani.SetPackageName("Evapotranspiration")
        clsReadInputs.SetPackageName("Evapotranspiration")

        clsETPenmanMonteith.SetRCommand("ET.PenmanMonteith")
        clsETPenmanMonteith.AddParameter("data", clsRFunctionParameter:=clsReadInputs, iPosition:=0)
        clsETPenmanMonteith.AddParameter("constants", "constants", iPosition:=1)
        clsETPenmanMonteith.AddParameter("ts", Chr(34) & "daily" & Chr(34), iPosition:=2)
        clsETPenmanMonteith.AddParameter("solar", Chr(34) & "sunshine hours" & Chr(34), iPosition:=3)
        clsETPenmanMonteith.AddParameter("crops", Chr(34) & "short" & Chr(34), iPosition:=5)
        clsETPenmanMonteith.AddParameter("message", Chr(34) & "yes" & Chr(34), iPosition:=6)

        clsHargreavesSamani.SetRCommand("ET.HargreavesSamani")
        clsHargreavesSamani.AddParameter("data", clsRFunctionParameter:=clsReadInputs, iPosition:=0)
        clsHargreavesSamani.AddParameter("constants", "constants", iPosition:=1)
        clsHargreavesSamani.AddParameter("ts", Chr(34) & "daily" & Chr(34), iPosition:=2)

        clsDataFunctionPM.SetPackageName("base")
        clsDataFunctionHS.SetPackageName("base")
        clsDataFunctionPM.SetRCommand("data.frame")
        clsDataFunctionHS.SetRCommand("data.frame")

        clsReadInputs.SetRCommand("ReadInputs")
        clsReadInputs.AddParameter("constants", "constants", iPosition:=2)
        clsReadInputs.AddParameter("stopmissing", iPosition:=3)
        clsReadInputs.AddParameter("timestep", Chr(34) & "daily" & Chr(34), iPosition:=4)
        clsReadInputs.AddParameter("interp_missing_days", "FALSE", iPosition:=5)
        clsReadInputs.AddParameter("interp_missing_entries", "FALSE", iPosition:=6)
        clsReadInputs.AddParameter("interp_abnormal", "FALSE", iPosition:=7)
        clsReadInputs.AddParameter("missing_method", "NULL", iPosition:=8)
        clsReadInputs.AddParameter("abnormal_method", "NULL", iPosition:=9)

        clsDailyOperatorPM.SetOperation("$")
        clsDailyOperatorPM.AddParameter("ET.PenmanMonteith", clsRFunctionParameter:=clsETPenmanMonteith, iPosition:=0)
        clsDailyOperatorPM.AddParameter("ET.Daily", strParameterValue:="ET.Daily", iPosition:=1)

        clsDailyOperatorHS.SetOperation("$")
        clsDailyOperatorHS.AddParameter("ET.HargreavesSamani", clsRFunctionParameter:=clsHargreavesSamani, iPosition:=0)
        clsDailyOperatorHS.AddParameter("ET.Daily", strParameterValue:="ET.Daily", iPosition:=1)

        clsDailyOperatorPM.SetAssignTo(UcrNewColumnName.GetText, strTempDataframe:=ucrSelectorEvaop.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempColumn:=UcrNewColumnName.GetText)

        ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorPM)
    End Sub

    Private Sub SetRCodeForControls(bReset As Boolean)
        ucrReceiverYear.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Year", 0), iAdditionalPairNo:=1)
        ucrReceiverMonth.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Month", 1), iAdditionalPairNo:=1)
        ucrReceiverDay.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Day", 2), iAdditionalPairNo:=1)
        ucrReceiverTmax.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Tmax", 3), iAdditionalPairNo:=1)
        UcrReceiverTmin.AddAdditionalCodeParameterPair(clsDataFunctionHS, New RParameter("Tmin", 4), iAdditionalPairNo:=1)
        UcrInputTimeStep.AddAdditionalCodeParameterPair(clsHargreavesSamani, New RParameter("ts", 2), iAdditionalPairNo:=1)
        UcrChkSaveCSV.AddAdditionalCodeParameterPair(clsHargreavesSamani, New RParameter("save.csv", 4), iAdditionalPairNo:=1)
        UcrNewColumnName.AddAdditionalRCode(clsDailyOperatorHS, iAdditionalPairNo:=1)
        UcrPnlMethod.SetRCode(ucrBase.clsRsyntax.clsBaseOperator, bReset)
        ucrReceiverYear.SetRCode(clsDataFunctionPM, bReset)
        ucrReceiverMonth.SetRCode(clsDataFunctionPM, bReset)
        ucrReceiverDay.SetRCode(clsDataFunctionPM, bReset)
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
        UcrNewColumnName.SetRCode(ucrBase.clsRsyntax.clsBaseOperator, bReset)
    End Sub

    Private Sub TestOKEnabled()
        If UcrNewColumnName.IsComplete() Then
            If rdoPenmanMonteith.Checked Then
                If UcrNewColumnName.IsComplete AndAlso (Not ucrReceiverYear.IsEmpty()) AndAlso (Not ucrReceiverMonth.IsEmpty()) AndAlso (Not ucrReceiverDay.IsEmpty()) AndAlso (Not ucrReceiverTmax.IsEmpty()) AndAlso (Not UcrReceiverTmin.IsEmpty()) AndAlso (Not UcrReceiverHumidityMax.IsEmpty()) AndAlso (Not UcrReceiverHumidityMin.IsEmpty()) AndAlso (Not UcrReceiverRadiation.IsEmpty()) AndAlso (Not UcrReceiverWindSpeed.IsEmpty()) AndAlso Not UcrInputTimeStep.IsEmpty AndAlso Not UcrInputSolar.IsEmpty AndAlso Not UcrInputCrop.IsEmpty Then
                    ucrBase.OKEnabled(True)
                Else
                    ucrBase.OKEnabled(False)
                End If
            ElseIf rdoHargreavesSamani.Checked Then
                If UcrNewColumnName.IsComplete AndAlso Not ucrReceiverYear.IsEmpty() AndAlso (Not ucrReceiverMonth.IsEmpty()) AndAlso (Not ucrReceiverDay.IsEmpty()) AndAlso (Not ucrReceiverTmax.IsEmpty()) AndAlso (Not UcrReceiverTmin.IsEmpty()) AndAlso (Not UcrInputTimeStep.IsEmpty()) Then
                    ucrBase.OKEnabled(True)
                Else
                    ucrBase.OKEnabled(False)
                End If
            End If
        Else
            ucrBase.OKEnabled(False)
        End If
    End Sub

    Private Sub ucrBase_ClickReset(sender As Object, e As EventArgs) Handles ucrBase.ClickReset
        SetDefaults()
        SetRCodeForControls(True)
        TestOKEnabled()
    End Sub

    Private Sub ucrPnlMethod_ControlValueChanged(ucrChangedControl As ucrCore) Handles UcrPnlMethod.ControlValueChanged, UcrInputTimeStep.ControlValueChanged, UcrInputSolar.ControlValueChanged, UcrInputCrop.ControlValueChanged
        If rdoPenmanMonteith.Checked Then
            clsReadInputs.AddParameter("varnames", "c(Tmax, Tmin, RHmax, RHmin, Rs, u2)", iPosition:=0)
            clsReadInputs.AddParameter("climatedata", clsRFunctionParameter:=clsDataFunctionPM, iPosition:=1)
            clsDailyOperatorPM.SetAssignTo(UcrNewColumnName.GetText, strTempDataframe:=ucrSelectorEvaop.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempColumn:=UcrNewColumnName.GetText)
            ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorPM)
        ElseIf rdoHargreavesSamani.Checked Then
            clsReadInputs.AddParameter("varnames", "c(Tmax, Tmin)", iPosition:=0)
            clsReadInputs.AddParameter("climatedata", clsRFunctionParameter:=clsDataFunctionHS, iPosition:=1)
            clsDailyOperatorHS.SetAssignTo(UcrNewColumnName.GetText, strTempDataframe:=ucrSelectorEvaop.ucrAvailableDataFrames.cboAvailableDataFrames.Text, strTempColumn:=UcrNewColumnName.GetText)
            ucrBase.clsRsyntax.SetBaseROperator(clsDailyOperatorHS)
        End If
    End Sub

    Private Sub ucrReceiverTmax_ControlContentsChanged(ucrChangedControl As ucrCore) Handles UcrReceiverWindSpeed.ControlValueChanged, UcrReceiverRadiation.ControlValueChanged, UcrReceiverHumidityMin.ControlValueChanged, UcrReceiverHumidityMax.ControlValueChanged, UcrReceiverTmin.ControlValueChanged, ucrReceiverTmax.ControlValueChanged, ucrReceiverYear.ControlValueChanged, ucrReceiverMonth.ControlValueChanged, ucrReceiverDay.ControlValueChanged
        TestOKEnabled()
    End Sub

    Private Sub ucrInputTimeStep_ControlValueChanged(ucrChangedControl As ucrCore) Handles UcrInputTimeStep.ControlValueChanged
        If UcrInputTimeStep.IsEmpty AndAlso rdoPenmanMonteith.Checked Then
            clsETPenmanMonteith.RemoveParameterByName("ts")
        ElseIf rdoHargreavesSamani.Checked AndAlso rdoHargreavesSamani.Checked Then
            clsHargreavesSamani.RemoveParameterByName("ts")
        ElseIf Not UcrInputTimeStep.IsEmpty AndAlso rdoPenmanMonteith.Checked Then
            clsETPenmanMonteith.AddParameter("ts", UcrInputTimeStep.GetText(), iPosition:=2)
        ElseIf Not UcrInputTimeStep.IsEmpty AndAlso rdoHargreavesSamani.Checked Then
            clsHargreavesSamani.AddParameter("ts", UcrInputTimeStep.GetText(), iPosition:=2)
        End If
    End Sub

    Private Sub ucrInputSolar_ControlValueChanged(ucrChangedControl As ucrCore) Handles UcrInputSolar.ControlValueChanged
        If UcrInputSolar.IsEmpty Then
            clsETPenmanMonteith.RemoveParameterByName("solar")
        Else
            clsETPenmanMonteith.AddParameter("solar", UcrInputSolar.GetText(), iPosition:=6)
        End If
    End Sub

    'Private Sub ucrSelectorCorrelation_ControlContentsChanged(ucrChangedControl As ucrCore) Handles ucrSelectorCorrelation.ControlContentsChanged
    'clsTempFunc = ucrSelectorCorrelation.ucrAvailableDataFrames.clsCurrDataFrame
    'End Sub


End Class



<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgEvapotranspiration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(dlgEvapotranspiration))
        Me.lblTmax = New System.Windows.Forms.Label()
        Me.lblTmin = New System.Windows.Forms.Label()
        Me.lblHumidityMax = New System.Windows.Forms.Label()
        Me.lblHumidityMin = New System.Windows.Forms.Label()
        Me.lblTimeStep = New System.Windows.Forms.Label()
        Me.lblCrop = New System.Windows.Forms.Label()
        Me.rdoPenmanMonteith = New System.Windows.Forms.RadioButton()
        Me.rdoHargreavesSamani = New System.Windows.Forms.RadioButton()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.grpMissingDataOpts = New System.Windows.Forms.GroupBox()
        Me.lblMissingMethod = New System.Windows.Forms.Label()
        Me.ucrInputComboBoxMissingMethod = New instat.ucrInputComboBox()
        Me.lblMaxPerctMissingDays = New System.Windows.Forms.Label()
        Me.lblMaxPerctDurationMissingData = New System.Windows.Forms.Label()
        Me.lblMaxPerctMissindData = New System.Windows.Forms.Label()
        Me.ucrChkInterpMissingEntries = New instat.ucrCheck()
        Me.ucrChkInterpMissingDays = New instat.ucrCheck()
        Me.ucrNudMaxMissingDays = New instat.ucrNud()
        Me.ucrNudMaxDurationMissingData = New instat.ucrNud()
        Me.ucrNudMaxMissingData = New instat.ucrNud()
        Me.ucrPnlSolar = New instat.UcrPanel()
        Me.UcrInputCrop = New instat.ucrInputComboBox()
        Me.ucrNewColName = New instat.ucrSave()
        Me.ucrReceiverDate = New instat.ucrReceiverSingle()
        Me.UcrPnlMethod = New instat.UcrPanel()
        Me.UcrInputTimeStep = New instat.ucrInputComboBox()
        Me.UcrReceiverHumidityMin = New instat.ucrReceiverSingle()
        Me.UcrReceiverHumidityMax = New instat.ucrReceiverSingle()
        Me.UcrReceiverTmin = New instat.ucrReceiverSingle()
        Me.ucrReceiverTmax = New instat.ucrReceiverSingle()
        Me.ucrSelectorEvaop = New instat.ucrSelectorByDataFrameAddRemove()
        Me.ucrBase = New instat.ucrButtons()
        Me.ucrPnlWindSpeed = New instat.UcrPanel()
        Me.grpSolar = New System.Windows.Forms.GroupBox()
        Me.lblCloudCover = New System.Windows.Forms.Label()
        Me.lblSunshineHrs = New System.Windows.Forms.Label()
        Me.UcrInputSolar = New instat.ucrInputComboBox()
        Me.lblSolar = New System.Windows.Forms.Label()
        Me.UcrReceiverRadiation = New instat.ucrReceiverSingle()
        Me.lblRadiation = New System.Windows.Forms.Label()
        Me.grpWindSpeed = New System.Windows.Forms.GroupBox()
        Me.UcrChkWind = New instat.ucrCheck()
        Me.lblWindSpeed = New System.Windows.Forms.Label()
        Me.UcrReceiverWindSpeed = New instat.ucrReceiverSingle()
        Me.grpMissingDataOpts.SuspendLayout()
        Me.grpSolar.SuspendLayout()
        Me.grpWindSpeed.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTmax
        '
        resources.ApplyResources(Me.lblTmax, "lblTmax")
        Me.lblTmax.Name = "lblTmax"
        '
        'lblTmin
        '
        resources.ApplyResources(Me.lblTmin, "lblTmin")
        Me.lblTmin.Name = "lblTmin"
        '
        'lblHumidityMax
        '
        resources.ApplyResources(Me.lblHumidityMax, "lblHumidityMax")
        Me.lblHumidityMax.Name = "lblHumidityMax"
        '
        'lblHumidityMin
        '
        resources.ApplyResources(Me.lblHumidityMin, "lblHumidityMin")
        Me.lblHumidityMin.Name = "lblHumidityMin"
        '
        'lblTimeStep
        '
        resources.ApplyResources(Me.lblTimeStep, "lblTimeStep")
        Me.lblTimeStep.Name = "lblTimeStep"
        '
        'lblCrop
        '
        resources.ApplyResources(Me.lblCrop, "lblCrop")
        Me.lblCrop.Name = "lblCrop"
        '
        'rdoPenmanMonteith
        '
        resources.ApplyResources(Me.rdoPenmanMonteith, "rdoPenmanMonteith")
        Me.rdoPenmanMonteith.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoPenmanMonteith.FlatAppearance.BorderSize = 2
        Me.rdoPenmanMonteith.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoPenmanMonteith.Name = "rdoPenmanMonteith"
        Me.rdoPenmanMonteith.TabStop = True
        Me.rdoPenmanMonteith.UseVisualStyleBackColor = True
        '
        'rdoHargreavesSamani
        '
        resources.ApplyResources(Me.rdoHargreavesSamani, "rdoHargreavesSamani")
        Me.rdoHargreavesSamani.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoHargreavesSamani.FlatAppearance.BorderSize = 2
        Me.rdoHargreavesSamani.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.rdoHargreavesSamani.Name = "rdoHargreavesSamani"
        Me.rdoHargreavesSamani.TabStop = True
        Me.rdoHargreavesSamani.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        resources.ApplyResources(Me.lblDate, "lblDate")
        Me.lblDate.Name = "lblDate"
        '
        'grpMissingDataOpts
        '
        Me.grpMissingDataOpts.Controls.Add(Me.lblMissingMethod)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrInputComboBoxMissingMethod)
        Me.grpMissingDataOpts.Controls.Add(Me.lblMaxPerctMissingDays)
        Me.grpMissingDataOpts.Controls.Add(Me.lblMaxPerctDurationMissingData)
        Me.grpMissingDataOpts.Controls.Add(Me.lblMaxPerctMissindData)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrChkInterpMissingEntries)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrChkInterpMissingDays)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrNudMaxMissingDays)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrNudMaxDurationMissingData)
        Me.grpMissingDataOpts.Controls.Add(Me.ucrNudMaxMissingData)
        resources.ApplyResources(Me.grpMissingDataOpts, "grpMissingDataOpts")
        Me.grpMissingDataOpts.Name = "grpMissingDataOpts"
        Me.grpMissingDataOpts.TabStop = False
        '
        'lblMissingMethod
        '
        resources.ApplyResources(Me.lblMissingMethod, "lblMissingMethod")
        Me.lblMissingMethod.Name = "lblMissingMethod"
        '
        'ucrInputComboBoxMissingMethod
        '
        Me.ucrInputComboBoxMissingMethod.AddQuotesIfUnrecognised = True
        Me.ucrInputComboBoxMissingMethod.IsReadOnly = False
        resources.ApplyResources(Me.ucrInputComboBoxMissingMethod, "ucrInputComboBoxMissingMethod")
        Me.ucrInputComboBoxMissingMethod.Name = "ucrInputComboBoxMissingMethod"
        '
        'lblMaxPerctMissingDays
        '
        resources.ApplyResources(Me.lblMaxPerctMissingDays, "lblMaxPerctMissingDays")
        Me.lblMaxPerctMissingDays.Name = "lblMaxPerctMissingDays"
        '
        'lblMaxPerctDurationMissingData
        '
        resources.ApplyResources(Me.lblMaxPerctDurationMissingData, "lblMaxPerctDurationMissingData")
        Me.lblMaxPerctDurationMissingData.Name = "lblMaxPerctDurationMissingData"
        '
        'lblMaxPerctMissindData
        '
        resources.ApplyResources(Me.lblMaxPerctMissindData, "lblMaxPerctMissindData")
        Me.lblMaxPerctMissindData.Name = "lblMaxPerctMissindData"
        '
        'ucrChkInterpMissingEntries
        '
        Me.ucrChkInterpMissingEntries.Checked = False
        resources.ApplyResources(Me.ucrChkInterpMissingEntries, "ucrChkInterpMissingEntries")
        Me.ucrChkInterpMissingEntries.Name = "ucrChkInterpMissingEntries"
        '
        'ucrChkInterpMissingDays
        '
        Me.ucrChkInterpMissingDays.Checked = False
        resources.ApplyResources(Me.ucrChkInterpMissingDays, "ucrChkInterpMissingDays")
        Me.ucrChkInterpMissingDays.Name = "ucrChkInterpMissingDays"
        '
        'ucrNudMaxMissingDays
        '
        Me.ucrNudMaxMissingDays.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxMissingDays.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudMaxMissingDays, "ucrNudMaxMissingDays")
        Me.ucrNudMaxMissingDays.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudMaxMissingDays.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxMissingDays.Name = "ucrNudMaxMissingDays"
        Me.ucrNudMaxMissingDays.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrNudMaxDurationMissingData
        '
        Me.ucrNudMaxDurationMissingData.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxDurationMissingData.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudMaxDurationMissingData, "ucrNudMaxDurationMissingData")
        Me.ucrNudMaxDurationMissingData.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudMaxDurationMissingData.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxDurationMissingData.Name = "ucrNudMaxDurationMissingData"
        Me.ucrNudMaxDurationMissingData.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrNudMaxMissingData
        '
        Me.ucrNudMaxMissingData.DecimalPlaces = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxMissingData.Increment = New Decimal(New Integer() {1, 0, 0, 0})
        resources.ApplyResources(Me.ucrNudMaxMissingData, "ucrNudMaxMissingData")
        Me.ucrNudMaxMissingData.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.ucrNudMaxMissingData.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.ucrNudMaxMissingData.Name = "ucrNudMaxMissingData"
        Me.ucrNudMaxMissingData.Value = New Decimal(New Integer() {0, 0, 0, 0})
        '
        'ucrPnlSolar
        '
        resources.ApplyResources(Me.ucrPnlSolar, "ucrPnlSolar")
        Me.ucrPnlSolar.Name = "ucrPnlSolar"
        '
        'UcrInputCrop
        '
        Me.UcrInputCrop.AddQuotesIfUnrecognised = True
        Me.UcrInputCrop.IsReadOnly = False
        resources.ApplyResources(Me.UcrInputCrop, "UcrInputCrop")
        Me.UcrInputCrop.Name = "UcrInputCrop"
        '
        'ucrNewColName
        '
        resources.ApplyResources(Me.ucrNewColName, "ucrNewColName")
        Me.ucrNewColName.Name = "ucrNewColName"
        '
        'ucrReceiverDate
        '
        Me.ucrReceiverDate.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverDate, "ucrReceiverDate")
        Me.ucrReceiverDate.Name = "ucrReceiverDate"
        Me.ucrReceiverDate.Selector = Nothing
        Me.ucrReceiverDate.strNcFilePath = ""
        Me.ucrReceiverDate.ucrSelector = Nothing
        '
        'UcrPnlMethod
        '
        resources.ApplyResources(Me.UcrPnlMethod, "UcrPnlMethod")
        Me.UcrPnlMethod.Name = "UcrPnlMethod"
        '
        'UcrInputTimeStep
        '
        Me.UcrInputTimeStep.AddQuotesIfUnrecognised = True
        Me.UcrInputTimeStep.IsReadOnly = False
        resources.ApplyResources(Me.UcrInputTimeStep, "UcrInputTimeStep")
        Me.UcrInputTimeStep.Name = "UcrInputTimeStep"
        '
        'UcrReceiverHumidityMin
        '
        Me.UcrReceiverHumidityMin.frmParent = Me
        resources.ApplyResources(Me.UcrReceiverHumidityMin, "UcrReceiverHumidityMin")
        Me.UcrReceiverHumidityMin.Name = "UcrReceiverHumidityMin"
        Me.UcrReceiverHumidityMin.Selector = Nothing
        Me.UcrReceiverHumidityMin.strNcFilePath = ""
        Me.UcrReceiverHumidityMin.ucrSelector = Nothing
        '
        'UcrReceiverHumidityMax
        '
        Me.UcrReceiverHumidityMax.frmParent = Me
        resources.ApplyResources(Me.UcrReceiverHumidityMax, "UcrReceiverHumidityMax")
        Me.UcrReceiverHumidityMax.Name = "UcrReceiverHumidityMax"
        Me.UcrReceiverHumidityMax.Selector = Nothing
        Me.UcrReceiverHumidityMax.strNcFilePath = ""
        Me.UcrReceiverHumidityMax.ucrSelector = Nothing
        '
        'UcrReceiverTmin
        '
        Me.UcrReceiverTmin.frmParent = Me
        resources.ApplyResources(Me.UcrReceiverTmin, "UcrReceiverTmin")
        Me.UcrReceiverTmin.Name = "UcrReceiverTmin"
        Me.UcrReceiverTmin.Selector = Nothing
        Me.UcrReceiverTmin.strNcFilePath = ""
        Me.UcrReceiverTmin.ucrSelector = Nothing
        '
        'ucrReceiverTmax
        '
        Me.ucrReceiverTmax.frmParent = Me
        resources.ApplyResources(Me.ucrReceiverTmax, "ucrReceiverTmax")
        Me.ucrReceiverTmax.Name = "ucrReceiverTmax"
        Me.ucrReceiverTmax.Selector = Nothing
        Me.ucrReceiverTmax.strNcFilePath = ""
        Me.ucrReceiverTmax.ucrSelector = Nothing
        '
        'ucrSelectorEvaop
        '
        Me.ucrSelectorEvaop.bShowHiddenColumns = False
        Me.ucrSelectorEvaop.bUseCurrentFilter = True
        resources.ApplyResources(Me.ucrSelectorEvaop, "ucrSelectorEvaop")
        Me.ucrSelectorEvaop.Name = "ucrSelectorEvaop"
        '
        'ucrBase
        '
        resources.ApplyResources(Me.ucrBase, "ucrBase")
        Me.ucrBase.Name = "ucrBase"
        '
        'ucrPnlWindSpeed
        '
        resources.ApplyResources(Me.ucrPnlWindSpeed, "ucrPnlWindSpeed")
        Me.ucrPnlWindSpeed.Name = "ucrPnlWindSpeed"
        '
        'grpSolar
        '
        Me.grpSolar.Controls.Add(Me.lblCloudCover)
        Me.grpSolar.Controls.Add(Me.lblSunshineHrs)
        Me.grpSolar.Controls.Add(Me.UcrInputSolar)
        Me.grpSolar.Controls.Add(Me.lblSolar)
        Me.grpSolar.Controls.Add(Me.UcrReceiverRadiation)
        Me.grpSolar.Controls.Add(Me.lblRadiation)
        resources.ApplyResources(Me.grpSolar, "grpSolar")
        Me.grpSolar.Name = "grpSolar"
        Me.grpSolar.TabStop = False
        '
        'lblCloudCover
        '
        resources.ApplyResources(Me.lblCloudCover, "lblCloudCover")
        Me.lblCloudCover.Name = "lblCloudCover"
        '
        'lblSunshineHrs
        '
        resources.ApplyResources(Me.lblSunshineHrs, "lblSunshineHrs")
        Me.lblSunshineHrs.Name = "lblSunshineHrs"
        '
        'UcrInputSolar
        '
        Me.UcrInputSolar.AddQuotesIfUnrecognised = True
        Me.UcrInputSolar.IsReadOnly = False
        resources.ApplyResources(Me.UcrInputSolar, "UcrInputSolar")
        Me.UcrInputSolar.Name = "UcrInputSolar"
        '
        'lblSolar
        '
        resources.ApplyResources(Me.lblSolar, "lblSolar")
        Me.lblSolar.Name = "lblSolar"
        '
        'UcrReceiverRadiation
        '
        Me.UcrReceiverRadiation.frmParent = Me
        resources.ApplyResources(Me.UcrReceiverRadiation, "UcrReceiverRadiation")
        Me.UcrReceiverRadiation.Name = "UcrReceiverRadiation"
        Me.UcrReceiverRadiation.Selector = Nothing
        Me.UcrReceiverRadiation.strNcFilePath = ""
        Me.UcrReceiverRadiation.ucrSelector = Nothing
        '
        'lblRadiation
        '
        resources.ApplyResources(Me.lblRadiation, "lblRadiation")
        Me.lblRadiation.Name = "lblRadiation"
        '
        'grpWindSpeed
        '
        Me.grpWindSpeed.Controls.Add(Me.UcrChkWind)
        Me.grpWindSpeed.Controls.Add(Me.lblWindSpeed)
        Me.grpWindSpeed.Controls.Add(Me.UcrReceiverWindSpeed)
        resources.ApplyResources(Me.grpWindSpeed, "grpWindSpeed")
        Me.grpWindSpeed.Name = "grpWindSpeed"
        Me.grpWindSpeed.TabStop = False
        '
        'UcrChkWind
        '
        Me.UcrChkWind.Checked = False
        resources.ApplyResources(Me.UcrChkWind, "UcrChkWind")
        Me.UcrChkWind.Name = "UcrChkWind"
        '
        'lblWindSpeed
        '
        resources.ApplyResources(Me.lblWindSpeed, "lblWindSpeed")
        Me.lblWindSpeed.Name = "lblWindSpeed"
        '
        'UcrReceiverWindSpeed
        '
        Me.UcrReceiverWindSpeed.frmParent = Me
        resources.ApplyResources(Me.UcrReceiverWindSpeed, "UcrReceiverWindSpeed")
        Me.UcrReceiverWindSpeed.Name = "UcrReceiverWindSpeed"
        Me.UcrReceiverWindSpeed.Selector = Nothing
        Me.UcrReceiverWindSpeed.strNcFilePath = ""
        Me.UcrReceiverWindSpeed.ucrSelector = Nothing
        '
        'dlgEvapotranspiration
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grpWindSpeed)
        Me.Controls.Add(Me.grpSolar)
        Me.Controls.Add(Me.ucrPnlSolar)
        Me.Controls.Add(Me.ucrPnlWindSpeed)
        Me.Controls.Add(Me.UcrInputCrop)
        Me.Controls.Add(Me.ucrNewColName)
        Me.Controls.Add(Me.grpMissingDataOpts)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.ucrReceiverDate)
        Me.Controls.Add(Me.rdoHargreavesSamani)
        Me.Controls.Add(Me.rdoPenmanMonteith)
        Me.Controls.Add(Me.UcrPnlMethod)
        Me.Controls.Add(Me.lblCrop)
        Me.Controls.Add(Me.lblTimeStep)
        Me.Controls.Add(Me.UcrInputTimeStep)
        Me.Controls.Add(Me.lblHumidityMin)
        Me.Controls.Add(Me.UcrReceiverHumidityMin)
        Me.Controls.Add(Me.lblHumidityMax)
        Me.Controls.Add(Me.UcrReceiverHumidityMax)
        Me.Controls.Add(Me.lblTmin)
        Me.Controls.Add(Me.UcrReceiverTmin)
        Me.Controls.Add(Me.lblTmax)
        Me.Controls.Add(Me.ucrReceiverTmax)
        Me.Controls.Add(Me.ucrSelectorEvaop)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEvapotranspiration"
        Me.grpMissingDataOpts.ResumeLayout(False)
        Me.grpMissingDataOpts.PerformLayout()
        Me.grpSolar.ResumeLayout(False)
        Me.grpSolar.PerformLayout()
        Me.grpWindSpeed.ResumeLayout(False)
        Me.grpWindSpeed.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents ucrSelectorEvaop As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblTmax As Label
    Friend WithEvents lblHumidityMin As Label
    Friend WithEvents UcrReceiverHumidityMin As ucrReceiverSingle
    Friend WithEvents lblHumidityMax As Label
    Friend WithEvents UcrReceiverHumidityMax As ucrReceiverSingle
    Friend WithEvents lblTmin As Label
    Friend WithEvents UcrReceiverTmin As ucrReceiverSingle
    Friend WithEvents lblCrop As Label
    Friend WithEvents UcrInputCrop As ucrInputComboBox
    Friend WithEvents lblTimeStep As Label
    Friend WithEvents UcrInputTimeStep As ucrInputComboBox
    Friend WithEvents rdoHargreavesSamani As RadioButton
    Friend WithEvents rdoPenmanMonteith As RadioButton
    Friend WithEvents UcrPnlMethod As UcrPanel
    Friend WithEvents ucrReceiverDate As ucrReceiverSingle
    Friend WithEvents lblDate As Label
    Friend WithEvents grpMissingDataOpts As GroupBox
    Friend WithEvents lblMaxPerctMissingDays As Label
    Friend WithEvents lblMaxPerctDurationMissingData As Label
    Friend WithEvents lblMaxPerctMissindData As Label
    Friend WithEvents ucrChkInterpMissingEntries As ucrCheck
    Friend WithEvents ucrChkInterpMissingDays As ucrCheck
    Friend WithEvents ucrNudMaxMissingDays As ucrNud
    Friend WithEvents ucrNudMaxDurationMissingData As ucrNud
    Friend WithEvents ucrNudMaxMissingData As ucrNud
    Friend WithEvents ucrInputComboBoxMissingMethod As ucrInputComboBox
    Friend WithEvents lblMissingMethod As Label
    Friend WithEvents ucrNewColName As ucrSave
    Friend WithEvents ucrReceiverTmax As ucrReceiverSingle
    Friend WithEvents ucrPnlSolar As UcrPanel
    Friend WithEvents grpWindSpeed As GroupBox
    Friend WithEvents UcrChkWind As ucrCheck
    Friend WithEvents lblWindSpeed As Label
    Friend WithEvents UcrReceiverWindSpeed As ucrReceiverSingle
    Friend WithEvents grpSolar As GroupBox
    Friend WithEvents lblCloudCover As Label
    Friend WithEvents lblSunshineHrs As Label
    Friend WithEvents UcrInputSolar As ucrInputComboBox
    Friend WithEvents lblSolar As Label
    Friend WithEvents UcrReceiverRadiation As ucrReceiverSingle
    Friend WithEvents lblRadiation As Label
    Friend WithEvents ucrPnlWindSpeed As UcrPanel
End Class

// VCDemoDlg.h : header file
//

#if !defined(AFX_VCDEMODLG_H__04CC4A4F_8271_454D_9707_069D9768F6E7__INCLUDED_)
#define AFX_VCDEMODLG_H__04CC4A4F_8271_454D_9707_069D9768F6E7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

//#include "LEDSender.h"

/////////////////////////////////////////////////////////////////////////////
// CVCDemoDlg dialog

class CVCDemoDlg : public CDialog
{
// Construction
public:
	int m_VsqFile;
	void GetDeviceParam(LPVOID param);
	void Parse2(long K);
	void Parse(long K);
	CVCDemoDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CVCDemoDlg)
	enum { IDD = IDD_VCDEMO_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CVCDemoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CVCDemoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnBtnPoweron();
	afx_msg void OnDestroy();
	afx_msg void OnBtnPoweroff();
	afx_msg void OnBtnAdjusttime();
	afx_msg void OnBtnSetbright();
	afx_msg void OnBtnGetpower();
	afx_msg void OnBtnGetbright();
	afx_msg void OnBtnText();
	afx_msg void OnBtnDib();
	afx_msg void OnBtnString();
	afx_msg void OnBtnDclock();
	afx_msg void OnLEDNotify(WPARAM wParam, LPARAM lParam); //消息处理
	afx_msg void OnTimer(UINT nIDEvent);
	afx_msg void OnBtnPicFile();
	afx_msg void OnBtnTimer();
	afx_msg void OnBtnThread();
	afx_msg void OnBtnAclock();
	afx_msg void OnBtnPoweron2();
	afx_msg void OnBtnPoweroff2();
	afx_msg void OnBtnGetpower2();
	afx_msg void OnBtnGetbright2();
	afx_msg void OnBtnSetbright2();
	afx_msg void OnBtnAdjusttime2();
	afx_msg void OnBtnText2();
	afx_msg void OnBtnDib2();
	afx_msg void OnBtnString2();
	afx_msg void OnBtnPicFile2();
	afx_msg void OnBtnDclock2();
	afx_msg void OnBtnAclock2();
	afx_msg void OnBtnVsq();
	afx_msg void OnBtnChapterBack();
	afx_msg void OnBtnChapterNext();
	afx_msg void OnBtnChapter();
	afx_msg void OnBtnRegion();
	afx_msg void OnBtnLeaf();
	afx_msg void OnBtnObject();
	afx_msg void OnBtnResetdisplay();
	afx_msg void OnBtnPoweron3();
	afx_msg void OnBtnOnline();
	afx_msg void OnBtnOnlineStart();
	afx_msg void OnBtnOnlineStop();
	afx_msg void OnBtnCampaign();
	afx_msg void OnBtnBoardParam();
	afx_msg void OnBtnComTransfer();
	afx_msg void OnBtnPowerschedule();
	afx_msg void OnBtnPreview();
	afx_msg void OnBtnMulti();
	afx_msg void OnBtnGetCurChapter();
	afx_msg void OnBtnTable();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	long GetColorType();
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_VCDEMODLG_H__04CC4A4F_8271_454D_9707_069D9768F6E7__INCLUDED_)

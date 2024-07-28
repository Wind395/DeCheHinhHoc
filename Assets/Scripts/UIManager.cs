using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // Danh sách tất cả các UI Panels
    public GameObject[] panels;

    // Danh sách tất cả các Buttons
    public Button[] buttons;

    // Button Exit để chuyển về scene login
    public Button logoutButton;


    void Start()
    {
        // Đảm bảo các panel đều ẩn khi bắt đầu (trừ panel đầu tiên)
        if (panels.Length > 0)
        {
            ShowPanel(panels[0]); // Hiển thị panel đầu tiên
        }

        // Đảm bảo các nút đã được gán trong Inspector và thiết lập sự kiện OnClick
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Cần phải sao chép biến index vào một biến tạm để tránh vấn đề với closures
            if (index < panels.Length)
            {
                buttons[i].onClick.AddListener(() => ShowPanel(panels[index]));
            }
        }

        // Thiết lập sự kiện cho nút Exit
        if (logoutButton != null)
        {
            logoutButton.onClick.AddListener(ExitToLoginScene);
        }
    }

    public void ShowPanel(GameObject panelToShow)
    {
        // Ẩn tất cả các panel
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        // Hiển thị panel được chọn
        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ExitToLoginScene()
    {
        // Chuyển đến scene login
        SceneManager.LoadScene("LoginUI"); // Thay "LoginScene" bằng tên scene bạn muốn chuyển đến
    }

    public void NextLevel() {
        SceneManager.LoadScene(2);
    }
}

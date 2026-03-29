Feature: LINE 關鍵字偵測
    身為內容審核人員
    我想要偵測包含 LINE 聯絡方式的訊息
    以便進行審查

    Scenario Outline: 偵測各種格式的 LINE 關鍵字
        Given 輸入文字為 "<input>"
        When 檢查是否包含 LINE 關鍵字
        Then 結果應為 <expected>

        Examples:
            | input                  | expected |
            | 留下LINE               | true     |
            | 留下line               | true     |
            | 留下Line               | true     |
            | 留下 LINE              | true     |
            | 留 下 LINE             | true     |
            | 留下ＬＩＮＥ             | true     |
            | 留下ｌｉｎｅ             | true     |
            | 留下 Ｌｉｎｅ           | true     |
            | 留下賴                  | true     |
            | 留 下 賴               | true     |
            | 留下　LINE             | true     |
            | 請留下LINE聯絡          | true     |
            | 今天天氣很好            | false    |
            | LINE好用               | false    |
            | 留下電話               | false    |

    Scenario Outline: 偵測 HTML 格式內的 LINE 關鍵字
        Given 輸入 HTML 為 "<html>"
        When 檢查 HTML 是否包含 LINE 關鍵字
        Then 結果應為 <expected>

        Examples:
            | html                                  | expected |
            | <b>留下</b>LINE                       | true     |
            | 留下<span>LINE</span>                 | true     |
            | <p>留下賴</p>                         | true     |
            | <b>留下</b>&nbsp;LINE                 | true     |
            | &lt;留下LINE&gt;                      | true     |
            | <p>今天天氣很好</p>                   | false    |
            | <b>LINE好用</b>                       | false    |

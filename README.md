# LineKeywordMatcher

偵測文字或 HTML 中是否含有要求留下 LINE 聯絡方式的關鍵字，用於內容審核情境。

## 功能

- 偵測純文字中的 LINE 關鍵字
- 偵測 HTML 內容中的 LINE 關鍵字（支援標籤、HTML entities）
- 正規化處理：忽略空白、全形轉半形、大小寫不敏感

## 偵測規則

關鍵字由外部注入，比對前會自動正規化：

- 忽略空白（全形空白 `　`、半形空白）
- 全形英文轉半形（`ＡＢＣＤ` → `ABCD`）
- 英文字母轉小寫

預設建議關鍵字：

| 關鍵字 | 可辨識的變體 |
|--------|------------|
| `留下line` | `留下LINE`、`留下ｌｉｎｅ`、`留下 Ｌｉｎｅ`、`留 下 LINE` |
| `留下賴`   | `留下賴`、`留 下 賴` |

## 使用方式

建立 matcher 時注入關鍵字，關鍵字來源可自由決定（設定檔、DB、Redis 等）。

```csharp
// 建立 matcher，注入關鍵字
var matcher = new LineContactKeywordMatcher(["留下line", "留下賴"]);

// 純文字
bool result = matcher.ContainsLineKeyword("請留下LINE聯絡");
// → true

// HTML
bool result = matcher.ContainsLineKeywordInHtml("<b>留下</b>&nbsp;LINE");
// → true
```

搭配 DI 容器（以 ASP.NET Core 為例）：

```csharp
// Program.cs
builder.Services.AddSingleton(sp =>
{
    var keywords = sp.GetRequiredService<IConfiguration>()
                     .GetSection("LineKeywords").Get<string[]>()!;
    return new LineContactKeywordMatcher(keywords);
});
```

## 執行測試

```bash
dotnet test
```

## 專案結構

```
src/
└── LineKeywordMatcher/
    ├── LineContactKeywordMatcher.cs   # 主要比對邏輯
    └── HtmlTextExtractor.cs           # HTML 轉純文字

tests/
└── LineKeywordMatcher.Specs/
    ├── Features/LineKeywordDetection.feature   # BDD 測試情境
    └── StepDefinitions/                        # SpecFlow 步驟定義
```

## 技術

- .NET 8
- [HtmlAgilityPack](https://html-agility-pack.net/) — HTML 解析
- [SpecFlow](https://specflow.org/) + xUnit — BDD 測試

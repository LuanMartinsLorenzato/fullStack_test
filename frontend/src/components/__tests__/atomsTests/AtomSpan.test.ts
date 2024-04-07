import { mount } from '@vue/test-utils'
import AtomSpan from '../../atoms/AtomSpan.vue'
import { describe, expect, test } from 'vitest'

describe(AtomSpan, () => {
  const slotText = 'Text'

  test('Renders with default styleType "Input"', async () => {
    const wrapper = mount(AtomSpan, {
      slots: {
        default: slotText
      }
    })
    expect(wrapper.exists()).toBe(true)
    expect(wrapper.classes()).toContain('Input')
  })

  test('Renders with custom styleType "Text"', async () => {
    const wrapper = mount(AtomSpan, {
      props: {
        styleType: 'Text'
      },
      slots: {
        default: slotText
      }
    })
    expect(wrapper.classes()).toContain('Text')
    expect(wrapper.text()).toBe(slotText)
  })
})
